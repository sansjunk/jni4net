// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

package org.drools.runtime.process;

@net.sf.jni4net.attributes.ClrTypeInfo
public final class NodeInstance_ {
    
    //<generated-static>
    private static system.Type staticType;
    
    public static system.Type typeof() {
        return org.drools.runtime.process.NodeInstance_.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        org.drools.runtime.process.NodeInstance_.staticType = staticType;
    }
    //</generated-static>
}

//<generated-proxy>
@net.sf.jni4net.attributes.ClrProxy
class __NodeInstance extends system.Object implements org.drools.runtime.process.NodeInstance {
    
    protected __NodeInstance(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("()J")
    public native long getId();
    
    @net.sf.jni4net.attributes.ClrMethod("()Lorg/drools/runtime/process/WorkflowProcessInstance;")
    public native org.drools.runtime.process.WorkflowProcessInstance getProcessInstance();
    
    @net.sf.jni4net.attributes.ClrMethod("()J")
    public native long getNodeId();
    
    @net.sf.jni4net.attributes.ClrMethod("()Ljava/lang/String;")
    public native java.lang.String getNodeName();
    
    @net.sf.jni4net.attributes.ClrMethod("()Lorg/drools/runtime/process/NodeInstanceContainer;")
    public native org.drools.runtime.process.NodeInstanceContainer getNodeInstanceContainer();
}
//</generated-proxy>