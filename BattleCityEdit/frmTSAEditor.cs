using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BattleCityEdit
{
    public partial class frmTSAEditor : Form
    {
        BattleCityLib.BattleCityData _BCData;
        int _TileX;
        int _TileY;
        byte _PaletteIndex = 0;
        public frmTSAEditor(ref BattleCityLib.BattleCityData bcData)
        {
            InitializeComponent();
            _BCData = bcData;
        }

        private void frmTSAEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Reset the owner's curtsatile property to -1.
            (this.Owner as frmMain).CurTSATile = -1;
        }

        private void frmTSAEditor_Load(object sender, EventArgs e)
        {
            // Reset the owner's curtsatile property to -1.
            (this.Owner as frmMain).CurTSATile = 0;
        }

        private void picPatternTable_Paint(object sender, PaintEventArgs e)
        {
            if (_BCData != null)
            {
                Bitmap pat = new Bitmap(128, 128, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                _BCData.DrawBGPatternTable(ref pat, _PaletteIndex);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(pat, 0, 0, pat.Width * 2, pat.Height * 2);
                e.Graphics.DrawRectangle(new Pen(Color.Red, 2.0F), _TileX, _TileY, 16, 16);
            }
        }

        private void picPatternTable_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int Tile;
                Tile = ((e.Y / 16) * 16 * 16) + ((e.X / 16) * 16);
                _TileX = (e.X / 16) * 16;
                _TileY = (e.Y / 16) * 16;
                (this.Owner as frmMain).CurTSATile = Tile / 16;
                
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (_PaletteIndex == 3)
                    _PaletteIndex = 0;
                else
                    _PaletteIndex += 1;
            }

            // Refresh the currently displayed pattern table.
            picPatternTable.Invalidate();

        }
    }
}
