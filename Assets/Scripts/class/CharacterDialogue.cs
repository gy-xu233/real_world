using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogue
{
    public List<string> dialogueContent;
    public CharacterDialogue()              //待实现不同的对话内容，最好是能从文件直接加载，在记事本中写对话，然后从txt文件中加载
    {
        dialogueContent = new List<string>();
        dialogueContent.Add("初次见面，请多指教。");
        dialogueContent.Add("我的好友每去一个地方，都会给我飞鸽传书，你可以在我的主页看到许多我朋友的" +
            "消息。");
        dialogueContent.Add("当然你也可以去酒馆打听某人的行踪，不过酒馆的消息会迟缓很多，如果你正在寻找某个人的话，不妨" +
            "多和城市里的人聊聊，看看有没有人认识你要找的人，他会给你提供相当有用的信息。");
        dialogueContent.Add("这些信息都不是即时的，各种消息的传递都要考虑到实际的地理距离，所以你很难知道某人的实时位置。");
        dialogueContent.Add("如果还需要其他帮助的话，请联系作者，让他做吧。");


    }
}
