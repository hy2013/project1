﻿using UnityEngine;
using System.Collections;
using Game.AIBehaviorTree;

namespace Game.AIBehaviorTree
{
    public class ActionWalkForward : BNodeAction
    {
        public ActionWalkForward() : base()
        {
            m_strName = "WalkForwardAction";
        }

        public override void OnEnter(BInput input)
        {
            RoleInput pInput = (RoleInput)input;
            Animation playerAnim = pInput.Parent.RoleObject.GetComponent<Animation>();
            playerAnim[StateDef.PlayerAnimationClipName.WalkR].time = 0;
            playerAnim[StateDef.PlayerAnimationClipName.WalkR].wrapMode = WrapMode.Loop;
            playerAnim.Play(StateDef.PlayerAnimationClipName.WalkR);
        }

        public override ActionResult Excute(BInput input)
        {
            RoleInput tinput = input as RoleInput;
            if (GameData.Instance.BattleSceneActionFlag.HasFlag((long)StateDef.BattleActionFlag.InFighting))
                return ActionResult.FAILURE;

            if (tinput.Parent.RoleActionFlag.HasFlag((long)StateDef.PlayerActionFlag.WalkForward))
            {
                return ActionResult.RUNNING;
            }

            return ActionResult.SUCCESS;
        }
    }
}
