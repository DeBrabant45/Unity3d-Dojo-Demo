
using System;
using AD.Interfaces;

public interface IBlockable
{
    int BlockLevel { get; }
    bool IsBlocking { get; set; }
    Action OnBlockSuccessful { get; set; }
    ITagable AttackerTag { get; set; }
    bool IsBlockHitSuccessful();
}
