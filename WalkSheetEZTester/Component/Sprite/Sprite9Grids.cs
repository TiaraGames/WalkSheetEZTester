using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiaraFramework.Component.Extend;

namespace TiaraFramework.Component
{
    public struct NineGridInfo
    {
        public int widthL;
        public int widthR;
        public int heightU;
        public int heightD;
        public int widthC;
        public int heightC;
        public int centerWidth;
        public int centerHeight;
        public bool[] isLoop;

        public NineGridInfo(int widthL, int widthR, int heightU, int heightD, int widthC, int heightC, int centerWidth, int centerHeight, bool isLoop)
        {
            this.widthL = widthL;
            this.widthR = widthR;
            this.heightU = heightU;
            this.heightD = heightD;
            this.widthC = widthC;
            this.heightC = heightC;
            this.centerWidth = centerWidth;
            this.centerHeight = centerHeight;
            this.isLoop = new bool[4] { isLoop, isLoop, isLoop, isLoop };
        }

        public NineGridInfo(int widthL, int widthR, int heightU, int heightD, int widthC, int heightC, int centerWidth, int centerHeight, bool isLoopU, bool isLoopD, bool isLoopL, bool isLoopR)
            : this(widthL, widthR, heightU, heightD, widthC, heightC, centerWidth, centerHeight, true)
        {
            this.isLoop[0] = isLoopU;
            this.isLoop[1] = isLoopD;
            this.isLoop[2] = isLoopL;
            this.isLoop[3] = isLoopR;
        }
    }

    public class Sprite9Grids : ASprite
    {
        private Texture2D _texture;
        public Texture2D Texture { get { return _texture; } set { _texture = value; } }
        public NineGridInfo NineInfo { private set; get; }

        public Sprite9Grids(Vector2 position, Texture2D texture, NineGridInfo nineInfo, float depth, Game game)
            : base(game)
        {
            if (nineInfo.widthL > texture.Width || nineInfo.widthR > texture.Width ||
                nineInfo.heightD > texture.Height || nineInfo.heightU > texture.Height ||
                nineInfo.centerHeight > texture.Height || nineInfo.centerWidth > texture.Width)
                throw new Exception("Size error.");
            this.Position = position;
            this.Texture = texture;
            this.NineInfo = nineInfo;

            // Location numbers are according to Numpad
            // grid 7 (LT)
            Sprite sp7 = Sprite.OneFrameSprite(position, texture, depth, game);
            sp7.DrawRect = Short.Rect(nineInfo.widthL, nineInfo.heightU);

            // grid 8 (CT)
            Sprite sp8 = Sprite.OneFrameSprite(position + Short.VecX(nineInfo.widthL), texture, depth, game);
            sp8.DrawRect = Short.Rect(nineInfo.widthL, 0, nineInfo.widthC, nineInfo.heightU);
            // Scale or Loop
            sp7.AddSlave(sp8);

            // grid 9 (RT)
            Sprite sp9 = Sprite.OneFrameSprite(position + Short.VecX(nineInfo.widthL + nineInfo.centerWidth), texture, depth, game);
            sp9.DrawRect = Short.Rect(nineInfo.widthL + nineInfo.widthC, 0, nineInfo.widthR, nineInfo.heightU);
            sp7.AddSlave(sp9);

        }
    }
}
