using System;
using java.lang;
using net.sf.jni4net.jni;
using Boolean=java.lang.Boolean;
using Byte=java.lang.Byte;
using Double=java.lang.Double;
using Exception=System.Exception;
using String=java.lang.String;

namespace net.sf.jni4net.utils
{
    partial class Convertor
    {
        public static IntPtr FullC2J<TBoth>(JNIEnv env, TBoth obj)
        {
            // ReSharper disable CompareNonConstrainedGenericWithNull
            if (obj == null)
            {
                return IntPtr.Zero;
            }
            // ReSharper restore CompareNonConstrainedGenericWithNull
            Type reqType = typeof (TBoth);

            if (reqType.IsPrimitive)
            {
                return PrimC2J(env, obj, reqType);
            }
#if DEBUG
            if (reqType.IsArray)
            {
                throw new InvalidOperationException("Call ArrayFullJ2C<TRes, TElem> instead");
            }
#endif

            var proxy = obj as IJavaProxy;
            if (proxy != null && typeof(IJavaProxy).IsAssignableFrom(reqType))
            {
                if (Bridge.Debug)
                {
                    Class clazzT = env.GetObjectClass(proxy.Native);
                    RegistryRecord recordT = Registry.GetCLRRecord(reqType);
                    if (!recordT.JVMInterface.isAssignableFrom(clazzT))
                    {
                        throw new InvalidCastException("Can't cast JVM instance " + clazzT + " to " + reqType);
                    }
                }
                return proxy.Native;
            }

            Type realType = obj.GetType();
            if (reqType == typeof (String) && realType == typeof (string))
            {
                return StrongC2JString(env, (string) (object) obj);
            }

            //Now we deal only with CLR instances
            //or with wrapped JVM instances, which should stay wrapped

            RegistryRecord record = Registry.GetCLRRecord(realType);
            if (record.JVMProxy!=null &&  reqType.IsAssignableFrom(record.CLRInterface))
            {
                return record.CreateJVMProxy(env, obj);
            }
            record = Registry.GetCLRRecord(reqType);
            if (Bridge.Debug)
            {
                if (!record.CLRInterface.IsAssignableFrom(realType))
                {
                    throw new InvalidCastException("Can't cast JVM instance" + realType + " to " + reqType);
                }
            }
            return record.CreateJVMProxy(env, obj);
        }

        private static IntPtr PrimC2J(JNIEnv env, object obj, Type type)
        {
            if (type == typeof (int) || type == typeof (uint))
            {
                Value value = ParPrimC2J((int) obj);
                return env.CallStaticObjectMethodPtr(Integer.staticClass, intObject, value);
            }
            if (type == typeof (long) || type == typeof (ulong))
            {
                Value value = ParPrimC2J((long) obj);
                return env.CallStaticObjectMethodPtr(Long.staticClass, longObject, value);
            }
            if (type == typeof (bool))
            {
                Value value = ParPrimC2J((bool) obj);
                return env.CallStaticObjectMethodPtr(Boolean.staticClass, boolObject, value);
            }
            if (type == typeof (double))
            {
                Value value = ParPrimC2J((double) obj);
                return env.CallStaticObjectMethodPtr(Double.staticClass, doubleObject, value);
            }
            if (type == typeof (byte) || type == typeof (sbyte))
            {
                Value value = ParPrimC2J((byte) obj);
                return env.CallStaticObjectMethodPtr(Byte.staticClass, byteObject, value);
            }
            if (type == typeof (char))
            {
                Value value = ParPrimC2J((char) obj);
                return env.CallStaticObjectMethodPtr(Character.staticClass, charObject, value);
            }
            if (type == typeof (short) || type == typeof (ushort))
            {
                Value value = ParPrimC2J((short) obj);
                return env.CallStaticObjectMethodPtr(Short.staticClass, shortObject, value);
            }
            if (type == typeof (float))
            {
                Value value = ParPrimC2J((float) obj);
                return env.CallStaticObjectMethodPtr(Float.staticClass, floatObject, value);
            }
            throw new InvalidOperationException("Unknown simple type" + type);
        }

        internal static Value[] ConverArgs(JNIEnv env, object[] args)
        {
            if (args.Length == 0)
            {
                return null;
            }
            var jargs = new Value[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                var sarg = args[i] as string;
                if (sarg != null)
                {
                    jargs[i] = new Value {_object = env.NewStringPtr(sarg)};
                }
                else
                {
                    jargs[i] = new Value {_object = FullC2J(env, args[i])};
                }
            }
            return jargs;
        }
    }
}
