## 语法协议规则：syntax
目前的语法协议规则最新支持proto3
在文件描述为
```
yntax = "proto3";
```
每个.proto文件必须阐明支持的语法协议规则。
不同的规则要求的语法不一样，生成的.cc和.h文件也不一样，不能混用。

## 命名空间修饰：package
proto可以使用命名空间对该文件的所有内容进行匡制，命名空间的层级通过.进行延伸。
```
package zxtest.prototest;
```
生成的.cc和.h文件即有命名空间的匡制
```
namespace zxtest {
namespace prototest {
```
命名空间语法可以不加，不是必要的语法。

## 包含其他proto文件：import
proto文件可以引用其他proto文件的内容，关键字修饰后面加上引用的文件路径。
```
import "user.proto";
import "log.proto";
```
proto只能向下引用，不能解释“../”或“..\路径”，编译时会报错。
```
Backslashes, consecutive slashes, ".", or ".." are not allowed in the virtual path
```
工程构建禁止将proto文件分开放。若分开放就必须为其编写Makefile，定义输出路径。

## 注释
    和C与C++一样，proto文件通过“//”和“/**/”来注释。

3.5 数据类型
proto文件支持多种数据类型。

### 1、常见类型
```
string  ：字符串类型
int32   ：整型
uint32  ：无符号整型
sint32  ：有符号整型
bool    ：布尔类型
float   ：浮点型
```
### 2、枚举enum，在proto文件的定义，字段间隔为;
```
enum Recode {
    SUCCESS = 0;
    ERROR = 1;
};
```
## 消息体：message
proto文件就是围绕着消息体进行通信的，不同的协议规则对应不同的描述，本次阐述的是“proto3”的规则协议。

消息体内容组成：
```
[字段修饰] <数据类型|消息体|引用外部消息体> <名称> = <编号>；
```
## 字段修饰
```
required：声明该值是必要的值，不能为空（proto3舍弃）
optional：声明该值是可选的值，可以为空（proto3舍弃）
//proto3舍弃以上两种修饰，值都能为空

repeated：声明该值为多个数值，可以组成数组的形式
```
“proto3”仅仅支持repeated字段修饰，如果使用required，optional编译会报错。
```
Required fields are not allowed in proto3.
Explicit 'optional' labels are disallowed in the Proto3 syntax. To define 'optional' fields in Proto3, simply remove the 'optional' label, as fields are 'optional' by default.
```
“proto2”与“proto3”规则不兼容，将syntax = “proto2”之后，字段都需要强制加修饰，不然会报错。
```
Expected "required", "optional", or "repeated".
```

## 编号规则
```
message Testmessage {
    string                  name        = 1;
    Recode                  enumcode    = 2;
    repeated uint32         u32number   = 3;
    TestSendArray           Msg_array   = 4;
    zxtest.user.UserInfo    info        = 5;
}
```

引用外部类型有命名空间的一定要加命名空间延伸描述，编号必须是正整数，不然会报错。
```
Field numbers must be positive integers.
```