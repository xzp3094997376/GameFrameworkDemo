# 1.框架说明
## 1.1网络模块说明
### 1.1.1 序列化和反序列化
    第一次序列化：按照先包头，后包体顺序进行序列化和反序列化。
    第二次序列化：再次序列化，是为了修改Header中的PacketLength。

    注意：序列化和反序列化包头使用的函数类型需要保持一致。
## 1.2 Odin插件
   ### 1.2.1 odin 序列化和反序列化
        1.原理：
            扩展Unity 序列化
            unity 能序列化就用unity 进行序列化，否则使用odin序列化。
        2.序列化协议
            1.使用odin序列化
              继承odin 序列化类
              SerializedMonoBehaviour，
              SerializedScriptableObject等
            2.自定义序列化
              1.继承ISerializationCallbackReceiver接口
              2.实现接口方法
                OnAfterDeserialize
                   实现方法：UnitySerializationUtility.DeserializeUnityObject
                OnBeforeSerialize
                
  ### 1.2.2 odin Inspector(编辑器)
        1.
                
## 1.3 NodeGraphProcessor(可视化编程)