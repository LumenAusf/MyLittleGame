﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
 using PureMVCContent.Controller;
 using PureMVCContent.Model;

 public class PlayCommand : PureMVC.Patterns.MacroCommand
{

    protected override void InitializeMacroCommand()
    {
        AddSubCommand(typeof(Play1SubCommand));
        AddSubCommand(typeof(Play2SubCommand));
    }
}
