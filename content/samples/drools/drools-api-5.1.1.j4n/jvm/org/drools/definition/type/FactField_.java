// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

package org.drools.definition.type;

@net.sf.jni4net.attributes.ClrTypeInfo
public final class FactField_ {
    
    //<generated-static>
    private static system.Type staticType;
    
    public static system.Type typeof() {
        return org.drools.definition.type.FactField_.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        org.drools.definition.type.FactField_.staticType = staticType;
    }
    //</generated-static>
}

//<generated-proxy>
@net.sf.jni4net.attributes.ClrProxy
class __FactField extends system.Object implements org.drools.definition.type.FactField {
    
    protected __FactField(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("(Ljava/lang/Object;)V")
    public native void writeExternal(java.io.ObjectOutput par0);
    
    @net.sf.jni4net.attributes.ClrMethod("(Ljava/lang/Object;)V")
    public native void readExternal(java.io.ObjectInput par0);
    
    @net.sf.jni4net.attributes.ClrMethod("()Ljava/lang/String;")
    public native java.lang.String getName();
    
    @net.sf.jni4net.attributes.ClrMethod("(Ljava/lang/Object;)Ljava/lang/Object;")
    public native java.lang.Object get(java.lang.Object par0);
    
    @net.sf.jni4net.attributes.ClrMethod("()Ljava/lang/Class;")
    public native java.lang.Class getType();
    
    @net.sf.jni4net.attributes.ClrMethod("(Ljava/lang/Object;Ljava/lang/Object;)V")
    public native void set(java.lang.Object par0, java.lang.Object par1);
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native boolean isKey();
}
//</generated-proxy>