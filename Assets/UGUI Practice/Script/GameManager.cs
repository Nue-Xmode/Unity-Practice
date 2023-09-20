using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityPractice.UGUIPractice
{
    public class StoryBlock
    {
        public string story;
        public string option1Text;
        public string option2Text;
        public StoryBlock option1Block;
        public StoryBlock option2Block;

        public StoryBlock(string story, string option1Text, string option2Text, StoryBlock option1Block, StoryBlock option2Block)
        {
            this.story = story;
            this.option1Text = option1Text;
            this.option2Text = option2Text;
            this.option1Block = option1Block;
            this.option2Block = option2Block;
        }
        
        public StoryBlock(string story, string option1Text, string option2Text)
        {
            this.story = story;
            this.option1Text = option1Text;
            this.option2Text = option2Text;
        }
    }
    
    public class GameManager : MonoBehaviour
    {
        public Text mainText;

        public Button option1;
        public Text option1Text;

        public Button option2;
        public Text option2Text;

        private StoryBlock currentBlock;

        #region 故事节点

        private StoryBlock block1 = new StoryBlock("你在一间狭窄昏暗的城堡醒来", "尝试呼叫，看看这里有没有其他人", "查看面前的门");
        private StoryBlock block2 = new StoryBlock("你发了疯似地嚎叫，想要寻求帮助，可似乎这里只有你一个人", "停止无用的嚎叫并坐下", "查看面前的门");
        private StoryBlock block3 = new StoryBlock("你摸了摸面前的门，它似乎是一扇普通的木门，经过检查，它暂时无法打开，但是你注意到了它有一个锁！", "检查周围的地板", "什么也不做");
        private StoryBlock block4 = new StoryBlock("因为你很快就累了，所以你决定冷静下来并且尝试找到出去的路", "检查周围的地板", "检查你的口袋");
        private StoryBlock block5 = new StoryBlock("你翻遍了你的口袋，但是什么也没找到", "检查周围的地板", "查看面前的门");
        private StoryBlock block6 = new StoryBlock("地面上布满了石头，你开始慢慢地摸索，突然间，你的手触摸到了什么东西，是的，你找到了门的钥匙！！", "尝试打开门", "什么也不做");

        private StoryBlock block7 = new StoryBlock("你的钥匙成功地打开了门，你自由了！", "继续", "退出");
        private StoryBlock block8 = new StoryBlock("你决定永远地在这里坐着，寄！", "继续", "退出");

        #endregion

        private void Start()
        {
            currentBlock = block1;
            ShowMainText(currentBlock);
            
            SetStory();
            
            option1.onClick.AddListener(() =>
            {
                if (currentBlock.option1Block != null)
                    currentBlock = currentBlock.option1Block;
                else
                    currentBlock = block1;
            });
            
            option2.onClick.AddListener(() =>
            {
                if (currentBlock.option2Block != null)
                    currentBlock = currentBlock.option2Block;
                else
                {
                    currentBlock = null;
                    option1.enabled = false;
                    option2.enabled = false;
                }
            });
        }

        private void Update()
        {
            ShowMainText(currentBlock);
        }

        /// <summary>
        /// 显示对应文本
        /// </summary>
        private void ShowMainText(StoryBlock storyBlock)
        {
            if (currentBlock == null)
            {
                mainText.text = "感谢游玩！";
                option1Text.text = String.Empty;
                option2Text.text = String.Empty;
            }
            else
            {
                mainText.text = storyBlock.story;
                option1Text.text = storyBlock.option1Text;
                option2Text.text = storyBlock.option2Text;
            }
        }

        /// <summary>
        /// 设定故事
        /// </summary>
        private void SetStory()
        {
            block1.option1Block = block2;
            block1.option2Block = block3;

            block2.option1Block = block4;
            block2.option2Block = block3;
            
            block3.option1Block = block6;
            block3.option2Block = block8;
            
            block4.option1Block = block6;
            block4.option2Block = block5;
            
            block5.option1Block = block6;
            block5.option2Block = block3;
            
            block6.option1Block = block7;
            block6.option2Block = block8;
        }
    }
}