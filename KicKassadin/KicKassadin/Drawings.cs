using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Drawing;

namespace KicKassadin
{
    class Drawings {
        public static void Drawing_OnDraw(EventArgs args) {
            var drawOff = KassMenu.Config.Item("Drawings.Off").GetValue<bool>();
            var drawQ = KassMenu.Config.Item("Drawings.Q").GetValue<bool>();
            var drawW = KassMenu.Config.Item("Drawings.W").GetValue<bool>();
            var drawE = KassMenu.Config.Item("Drawings.E").GetValue<bool>();
            var drawR = KassMenu.Config.Item("Drawings.R").GetValue<bool>();

            if (drawOff)
                return;

            if (drawQ)
                if (KicKassadin.spells[Spells.Q].Level > 0)
                    Render.Circle.DrawCircle(ObjectManager.Player.Position, KicKassadin.spells[Spells.Q].Range, Color.White);

            if (drawE)
                if (KicKassadin.spells[Spells.E].Level > 0)
                    {
                  //  Render.Circle.DrawCircle(ObjectManager.Player.Position, KicKassadin.spells[Spells.E].Range, Color.White);
                    const int corkiERange = KicKassadin.spells[Spells.E].Range;
                    Render.Circle.DrawCircle(ObjectManager.Player.Position, KicKassadin.spells[Spells.E].Range, KicKassadin.spells[Spells.E].IsReady() ? Color.Green : Color.Red);
                    //var pos = ObjectManager.Player.Position.To2D() + 600 * ObjectManager.Player.Direction.To2D().Perpendicular();
                    Drawing.DrawCircle(pos.To3D(), 50, KicKassadin.spells[Spells.E].IsReady() ? Color.Green : Color.Red);
                    var playerPosition = ObjectManager.Player.Position.To2D();
                    var direction = ObjectManager.Player.Direction.To2D().Perpendicular();
                    var currentScreenPlayer = Drawing.WorldToScreen(ObjectManager.Player.Position);
                    var currentAngel = 30 * (float) Math.PI / 180;
                    var currentCheckPoint1 = playerPosition + corkiERange * direction.Rotated(currentAngel);
                    currentAngel = 335 * (float) Math.PI / 180;
                    var currentCheckPoint2 = playerPosition + corkiERange * direction.Rotated(currentAngel);
                    var currentScreenCheckPoint1 = Drawing.WorldToScreen(currentCheckPoint1.To3D());
                    var currentScreenCheckPoint2 = Drawing.WorldToScreen(currentCheckPoint2.To3D());
                    Drawing.DrawLine(currentScreenPlayer.X, currentScreenPlayer.Y, currentScreenCheckPoint1.X, currentScreenCheckPoint1.Y, 2, Corki.spells[Spells.E].IsReady() ? Color.Green : Color.Red);
                    Drawing.DrawLine(currentScreenPlayer.X, currentScreenPlayer.Y, currentScreenCheckPoint2.X, currentScreenCheckPoint2.Y,2,  Corki.spells[Spells.E].IsReady() ? Color.Green : Color.Red);
                        
                    }
            if (drawW)
                if (KicKassadin.spells[Spells.W].Level > 0)
                    Render.Circle.DrawCircle(ObjectManager.Player.Position, KicKassadin.spells[Spells.W].Range, Color.White);

            if (drawR)
                if (KicKassadin.spells[Spells.R].Level > 0)
                    Render.Circle.DrawCircle(ObjectManager.Player.Position, KicKassadin.spells[Spells.R].Range, Color.White);
        }
    }
}
