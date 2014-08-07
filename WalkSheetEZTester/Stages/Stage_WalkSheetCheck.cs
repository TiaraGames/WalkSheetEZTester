using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TiaraFramework.Component;
using TiaraFramework.Component.Extend;
using System.Windows.Forms;

namespace WalkSheetEZTester.Stages
{
    class Stage_WalkSheetCheck : Stage
    {
        Sprite spLeft;
        Sprite spRight;

        public Stage_WalkSheetCheck(Game game, float fps)
            : base(game, fps)
        {
            // Map
            List<Sprite> map = MapAccess.Load("Maps/Map1.XML", game);
            SprMgrClct["Map"].Add(map);

            // Chara Left
            spLeft = new Sprite(
                Short.Vec(2 * 32, 4 * 32), 
                game.Content.Load<Texture2D>("chara1"), 
                Short.Pt(3, 4),
                Short.Pt(48, 64), 
                1, game);
            spLeft.Origin = spLeft.CB;
            spLeft.PlayFramesNum = 3;
            spLeft.Loop.Style = LoopStyle.Reciprocation;
            spLeft.SetFPS(5);

            Sprite spShadow = Sprite.OneFrameSprite(spLeft.Position, Shape.GetRound(15, new Color(0, 0, 0, 120), game), 0.9f, game);
            spShadow.Origin = spShadow.CC;
            spShadow.Position = spLeft.Position + Short.VecY(-8);
            spLeft.AddSlave(spShadow);

            SprMgrClct["Player"].Add(spLeft);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


        }
    }
}
