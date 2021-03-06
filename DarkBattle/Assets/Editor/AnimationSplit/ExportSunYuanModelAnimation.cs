﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;


public class ExportSunYuanModelAnimation : ExportModelAnimation
{


    [MenuItem("Assets/Export Model Animation/导出孙元动作/技能3特效")]
    static void ExportYuLuoChaSkillEffect()
    {
        if (Selection.objects != null && Selection.objects.Length > 0)
        {
            foreach (UnityEngine.Object o in Selection.objects)
            {
                AnimationClip clip = o as AnimationClip;
                switch (clip.name)
                {
                    case "SYdimianyanchen01":
                        AnimationEventManager mgr = new AnimationEventManager(clip);
                        clip.frameRate = 30f;
                        mgr.AddAnimationEvent(4 / clip.frameRate, "AnimationEventBoxIn");
                        mgr.AddAnimationEvent(5 / clip.frameRate, "AnimationEventBoxOut");
                        mgr.AddAnimationEvent(clip.length, "AnimationEventEnd");
                        mgr.SaveAnimationEvent();
                        break;

                }
            }
        }
    }

    [MenuItem("Assets/Export Model Animation/导出孙元动作/动作")]
    static void ExportYuLuoCha()
    {
        //CurrentClipPlayer = ClipPlayer.YuLuoCha;
        ExportSunYuanModelAnimation a = new ExportSunYuanModelAnimation();
        a.Export();
    }
    [MenuItem("Assets/Export Model Animation/拷贝孙元")]
    public static void copy()
    {
        GameObject SunYuan = GameObject.Find("SunYuan");
        GameObject SunYuan20004 = GameObject.Find("20004");
        _copy(SunYuan20004, SunYuan, SunYuan);
    }

    public static void _copy(GameObject obj1, GameObject obj2, GameObject obj)
    {
        if (obj2)
        {
            obj2.tag = obj1.tag;
            obj2.layer = obj1.layer;
            Component[] mbs = obj1.transform.GetComponents<Component>();
            foreach (Component m in mbs)
            {
                Debug.Log(m.name + "UnityEditorInternal.ComponentUtility.CopyComponent(m);= " + UnityEditorInternal.ComponentUtility.CopyComponent(m));

                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(obj2);
            }
        }
        if (obj1.transform.childCount > 0)
        {
            for (int i = 0; i < obj1.transform.childCount; i++)
            {
                GameObject oo = obj1.transform.GetChild(i).gameObject;
                Transform tr = FindTransformInChild(obj.transform, oo.name);
                if (tr == null)
                    _copy(oo, null, obj);
                else
                {
                    _copy(oo, tr.gameObject, obj);
                }
            }
        }
    }
    #region 根据名字获取该游戏对象下子物体
    /// <summary>
    ///  根据名字获取该游戏对象下子物体
    /// </summary>
    /// <param name="tan">主要对象</param>
    /// <param name="name">当前的名字</param>
    /// <returns></returns>
    public static Transform FindTransformInChild(Transform tan, string name)
    {
        if (tan == null)
        {
            //Log.Error("ComUtil.FindTransformInChild -> tan Is Null + name =" + name);
            return null;
        }
        //Log.Debug("tan.name =" + tan.name + "/tan.childCount =" + tan.childCount);
        if (tan.name.Equals(name))
        {
            return tan;
        }
        if (tan.childCount == 0)
        {
            return null;
        }
        else
        {
            for (int i = 0; i < tan.childCount; i++)
            {
                Transform a = FindTransformInChild(tan.GetChild(i), name);
                if (a != null)
                {
                    return a;
                }
            }
            return null;
        }
    }
    #endregion
    public override void SetAnimationEvents(AnimationClip dstClip)
    {
        AnimationEventManager animationEventManager = new AnimationEventManager(dstClip);
        dstClip.frameRate = 30.0f;
        switch (dstClip.name)
        {
            case "ProvocationR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "ShakeR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                }
                break;
            case "WinR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "IdleR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                }
                break;
            case "BlockR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "HitBackR":
                {
                    animationEventManager.AddAnimationEvent(31 / dstClip.frameRate, "AnimationEventBoxIn");
                    animationEventManager.AddAnimationEvent(10 / dstClip.frameRate, "AnimationEventBoxIn1");
                    animationEventManager.AddAnimationEvent(20 / dstClip.frameRate, "AnimationEventBoxIn3"); // 落地烟尘激活 //
                    animationEventManager.AddAnimationEvent(45 / dstClip.frameRate, "AnimationEventBoxIn4"); //死亡使用//
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "SquatR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "SquatLoopR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                }
                break;
            case "SquatHitR":
                {
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventBoxIn3"); // 落地烟尘激活 //
                    animationEventManager.AddAnimationEvent(22 / dstClip.frameRate, "AnimationEventBoxIn4"); //死亡使用//
                    animationEventManager.AddAnimationEvent(10 / dstClip.frameRate, "AnimationEventLieDownBegin"); //躺地开始//
                    animationEventManager.AddAnimationEvent(30 / dstClip.frameRate, "AnimationEventLieDownEnd"); //躺地结束//
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "HoverR":
                {
                    animationEventManager.AddAnimationEvent(30 / dstClip.frameRate, "AnimationEventBoxIn");
                    animationEventManager.AddAnimationEvent(21 / dstClip.frameRate, "AnimationEventBoxIn3");// 落地烟尘激活 //
                    animationEventManager.AddAnimationEvent(45 / dstClip.frameRate, "AnimationEventBoxIn4"); //死亡使用//
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "LieDownR":
                {
                    animationEventManager.AddAnimationEvent(35 / dstClip.frameRate, "AnimationEventBoxIn");
                    animationEventManager.AddAnimationEvent(21 / dstClip.frameRate, "AnimationEventBoxIn3");// 落地烟尘激活 //
                    animationEventManager.AddAnimationEvent(45 / dstClip.frameRate, "AnimationEventBoxIn4"); //死亡使用//
                    animationEventManager.AddAnimationEvent(40 / dstClip.frameRate, "AnimationEventLieDownBegin"); //躺地开始//
                    animationEventManager.AddAnimationEvent(55 / dstClip.frameRate, "AnimationEventLieDownEnd"); //躺地结束//
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "JumpBackR":
            case "JumpR":
                {
                    animationEventManager.AddAnimationEvent(3 / dstClip.frameRate, "AnimationEventBoxIn");//触发跳跃//
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "Attack1R":
                {
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventBoxIn");
                    animationEventManager.AddAnimationEvent(13 / dstClip.frameRate, "AnimationEventBoxIn1");
                    animationEventManager.AddAnimationEvent(14 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown");//cooldown帧限制//
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "Attack2R":
                {
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventBoxIn");
                    animationEventManager.AddAnimationEvent(7 / dstClip.frameRate, "AnimationEventBoxIn1");
                    animationEventManager.AddAnimationEvent(2 / dstClip.frameRate, "AnimationEventMovePlay");//人物位移
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventMoveStop");//人物位移停止
                    animationEventManager.AddAnimationEvent(8 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown");//cooldown帧限制//
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "Attack3R":
                {
                    animationEventManager.AddAnimationEvent(7 / dstClip.frameRate, "AnimationEventBoxIn");
                    animationEventManager.AddAnimationEvent(12 / dstClip.frameRate, "AnimationEventBoxIn1");
                    animationEventManager.AddAnimationEvent(9 / dstClip.frameRate, "AnimationEventBoxIn2");
                    animationEventManager.AddAnimationEvent(14 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown");//cooldown帧限制//
                    animationEventManager.AddAnimationEvent(3 / dstClip.frameRate, "AnimationEventMovePlay");//人物位移
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventMoveStop");//人物位移停止
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "Attack4R":
                {
                    animationEventManager.AddAnimationEvent(2 / dstClip.frameRate, "AnimationEventBoxIn");//激活碰撞体//

                    animationEventManager.AddAnimationEvent(6 / dstClip.frameRate, "AnimationEventBoxIn1");//激活碰撞体//

                    animationEventManager.AddAnimationEvent(7 / dstClip.frameRate, "AnimationEventBoxIn2");//关闭碰撞体//
                    animationEventManager.AddAnimationEvent(12 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown");//cooldown帧限制//
                    animationEventManager.AddAnimationEvent(2 / dstClip.frameRate, "AnimationEventMovePlay");//人物位移
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventMoveStop");//人物位移停止
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "AttackSquat1R":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventBoxIn"); //触发碰撞体碰撞//
                    animationEventManager.AddAnimationEvent(8 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown");//cooldown帧限制//
                    animationEventManager.AddAnimationEvent(1 / dstClip.frameRate, "AnimationEventMovePlay");//人物位移
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventMoveStop");//人物位移停止
                    animationEventManager.AddAnimationEvent(9 / dstClip.frameRate, "AnimationEventBoxIn1"); //换下一个动作//

                }
                break;
            case "AttackSquat2R":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                    animationEventManager.AddAnimationEvent(2f / dstClip.frameRate, "AnimationEventBoxIn"); //触发碰撞体碰撞//
                    animationEventManager.AddAnimationEvent(4f / dstClip.frameRate, "AnimationEventBoxIn1"); //触发碰撞体碰撞//
                    animationEventManager.AddAnimationEvent(0 / dstClip.frameRate, "AnimationEventMovePlay");//人物位移
                    animationEventManager.AddAnimationEvent(3 / dstClip.frameRate, "AnimationEventMoveStop");//人物位移停止
                    //animationEventManager.AddAnimationEvent(14 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown");//cooldown帧限制//
                }
                break;
            case "Skill1R":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                    animationEventManager.AddAnimationEvent(12 / dstClip.frameRate, "AnimationEventBoxIn"); //开启特效//
                    animationEventManager.AddAnimationEvent(24 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown");//cooldown帧限制//
                }
                break;
            case "Skill2R":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventBoxIn"); //打开碰撞//
                    animationEventManager.AddAnimationEvent(14 / dstClip.frameRate, "AnimationEventBoxIn1"); //开始攻击判定//
                    animationEventManager.AddAnimationEvent(16 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown");//cooldown帧限制//
                }
                break;
            case "Skill3R":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;

                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventBoxIn"); //开始攻击判定//
                    animationEventManager.AddAnimationEvent(8 / dstClip.frameRate, "AnimationEventBoxIn1"); //不能攻击//
                    animationEventManager.AddAnimationEvent(4 / dstClip.frameRate, "AnimationEventMovePlay");//人物位移
                    animationEventManager.AddAnimationEvent(7 / dstClip.frameRate, "AnimationEventMoveStop");//人物位移停止
                    animationEventManager.AddAnimationEvent(20 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown");//cooldown帧限制//
                    /*animationEventManager.AddAnimationEvent(20 / dstClip.frameRate, "AnimationEventBoxIn1"); //倒地标示//*/
                    /*animationEventManager.AddAnimationEvent(21 / dstClip.frameRate, "AnimationEventBoxIn1"); //播放技能特效, 攻击判定结束//*/
                }
                break;
            case "Attack99R":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                    animationEventManager.AddAnimationEvent(0 / dstClip.frameRate, "AnimationEventBoxIn"); //触发碰撞体碰撞//
                   
                }
                break;
            case "Attack99LoopR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                }
                break;
            case "AirAttackR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                    animationEventManager.AddAnimationEvent(4 / dstClip.frameRate, "AnimationEventBoxIn"); //触发碰撞体碰撞//
                    animationEventManager.AddAnimationEvent(8 / dstClip.frameRate, "AnimationEventBoxIn1"); //触发碰撞体碰撞//
                    animationEventManager.AddAnimationEvent(10 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown");//cooldown帧限制//
                    animationEventManager.AddAnimationEvent(1 / dstClip.frameRate, "AnimationEventMovePlay");//人物位移
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventMoveStop");//人物位移停止
                }
                break;
            case "AirHitIdleR":
                {
                    animationEventManager.AddAnimationEvent(0 / dstClip.frameRate, "AnimationEventBoxIn3");// 落地烟尘激活 //
                    animationEventManager.AddAnimationEvent(19 / dstClip.frameRate, "AnimationEventBoxIn4"); //死亡使用//
                    animationEventManager.AddAnimationEvent(10 / dstClip.frameRate, "AnimationEventLieDownBegin"); //躺地开始//
                    animationEventManager.AddAnimationEvent(25 / dstClip.frameRate, "AnimationEventLieDownEnd"); //躺地结束//
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "AirRollR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "AirRollLoopR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                }
                break;
            case "ChargeStartR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "ChargeLoopR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                }
                break;
            case "ChargeAttackR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                    animationEventManager.AddAnimationEvent(4 / dstClip.frameRate, "AnimationEventBoxIn"); // 激活碰撞体 //
                    animationEventManager.AddAnimationEvent(6 / dstClip.frameRate, "AnimationEventBoxIn1"); //触发碰撞关闭//
                    animationEventManager.AddAnimationEvent(0 / dstClip.frameRate, "AnimationEventMovePlay");//人物位移
                    animationEventManager.AddAnimationEvent(3 / dstClip.frameRate, "AnimationEventMoveStop");//人物位移停止
                    animationEventManager.AddAnimationEvent(15 / dstClip.frameRate, "AnimationEventCanRemoveCoolDown"); //cooldown帧限制//
                }
                break;
            case "Hit1R":
            case "Hit2R":
            case "Hit3R":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "Jneng3HeJiuR":
            case "Jneng3QingXingR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "Jneng1HeJiuR":
                {
                    animationEventManager.AddAnimationEvent(7 / dstClip.frameRate, "AnimationEventBoxIn");
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "Jneng1QingXingR":
                {
                    animationEventManager.AddAnimationEvent(10 / dstClip.frameRate, "AnimationEventBoxIn");
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "Jneng2HeJiuR":
                {
                    animationEventManager.AddAnimationEvent(7 / dstClip.frameRate, "AnimationEventBoxIn");
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "Jneng2QingxingR":
                {
                    animationEventManager.AddAnimationEvent(11 / dstClip.frameRate, "AnimationEventBoxIn");
                    animationEventManager.AddAnimationEvent(15 / dstClip.frameRate, "AnimationEventBoxIn1");
                    animationEventManager.AddAnimationEvent(19 / dstClip.frameRate, "AnimationEventBoxIn2");
                    animationEventManager.AddAnimationEvent(22 / dstClip.frameRate, "AnimationEventBoxIn3");
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "PassiveAttack3R":
                {
                    animationEventManager.AddAnimationEvent(6 / dstClip.frameRate, "AnimationEventBoxIn");
                    animationEventManager.AddAnimationEvent(22 / dstClip.frameRate, "AnimationEventBoxIn1");
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "PassiveAttack2R":
                {
                    animationEventManager.AddAnimationEvent(6 / dstClip.frameRate, "AnimationEventBoxIn");
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "PassiveAttack1R":
                {
                    animationEventManager.AddAnimationEvent(6 / dstClip.frameRate, "AnimationEventBoxIn");
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "ChantR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                }
                break;
            case "WalkR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                    animationEventManager.AddAnimationEvent(1 / dstClip.frameRate, "AnimationMoveWardEventL");
                    animationEventManager.AddAnimationEvent(9 / dstClip.frameRate, "AnimationMoveWardEventR");
                    animationEventManager.AddAnimationEvent(23 / dstClip.frameRate, "AnimationMoveWardEventL");
                }
                break;
            case "WalkBackR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                    animationEventManager.AddAnimationEvent(1 / dstClip.frameRate, "AnimationMoveBackWardEventL");
                    animationEventManager.AddAnimationEvent(18 / dstClip.frameRate, "AnimationMoveBackWardEventR");
                    animationEventManager.AddAnimationEvent(20 / dstClip.frameRate, "AnimationMoveBackWardEventL");
                }
                break;
            case "QuickRunningR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                    //                     animationEventManager.AddAnimationEvent(1 / dstClip.frameRate, "AnimationMoveWardEventL");
                    //                     animationEventManager.AddAnimationEvent(9 / dstClip.frameRate, "AnimationMoveWardEventR"); 
                    //                     animationEventManager.AddAnimationEvent(23 / dstClip.frameRate, "AnimationMoveWardEventL"); 
                }
                break;
            case "QuickRunningBackR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                    //                     animationEventManager.AddAnimationEvent(1 / dstClip.frameRate, "AnimationMoveBackWardEventL");
                    //                     animationEventManager.AddAnimationEvent(18 / dstClip.frameRate, "AnimationMoveBackWardEventR");
                    //                     animationEventManager.AddAnimationEvent(28 / dstClip.frameRate, "AnimationMoveBackWardEventL"); 
                }
                break;
            case "ZhuanShenL":
            case "ZhuanShenR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "Hit3LoopR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                }
                break;
            case "BounceR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "HitSpinStartR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "HitSpinLoopR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                }
                break;
            case "HitSpinEndR":
                {
                    animationEventManager.AddAnimationEvent(24 / dstClip.frameRate, "AnimationEventBoxIn");// 死亡停止 //
                    animationEventManager.AddAnimationEvent(16 / dstClip.frameRate, "AnimationEventLieDownBegin"); //躺地开始//
                    animationEventManager.AddAnimationEvent(25 / dstClip.frameRate, "AnimationEventLieDownEnd"); //躺地结束//
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "HitbackStartR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "HitbackLoopR":
                {
                    dstClip.wrapMode = WrapMode.Loop;
                }
                break;
            case "HitbackEndR":
                {
                    animationEventManager.AddAnimationEvent(16 / dstClip.frameRate, "AnimationEventBoxIn");// 死亡停止 //
                    animationEventManager.AddAnimationEvent(5 / dstClip.frameRate, "AnimationEventLieDownBegin"); //躺地开始//
                    animationEventManager.AddAnimationEvent(20 / dstClip.frameRate, "AnimationEventLieDownEnd"); //躺地结束//
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "HitHardR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
            case "HitBellyR":
                {
                    dstClip.wrapMode = WrapMode.ClampForever;
                }
                break;
        }
        //             AnimationEvent endEvent = new AnimationEvent();
        //             endEvent.time = dstClip.length; // -0.0016f;
        //             endEvent.stringParameter = dstClip.name;
        //             endEvent.functionName = "AnimationEventEnd";

        animationEventManager.AddAnimationEvent(dstClip.length, "AnimationEventEnd");
        animationEventManager.SaveAnimationEvent();
    }
}
