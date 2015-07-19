using System;
using System.Drawing;
using System.Windows.Forms;
using BattleCityLib;
using System.IO;

namespace BattleCityEdit
{
    public partial class frmMain : Form
    {

        BattleCityData BCData;
        frmTSAEditor _TSA;
        public int CurTSATile { get; set; }
        EditorSetting _EditingMode = EditorSetting.None;
        public byte CurrentTile { get; set; }
        int _ObjUnderMouse = -1;
        bool _MouseDown = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Disable all the controls on the form.
            SetEnabledStatus(false);
            PopulateRecentMenu();
            ChangeEditingMode(EditorSetting.None);
        }

        /// <summary>
        /// Sets the enabled status of controls on the main form.
        /// </summary>
        /// <param name="Enabled">The enabled status of the form's controls.</param>
        private void SetEnabledStatus(bool Enabled)
        {
            picLevel.Enabled = Enabled;
            picTileSelector.Enabled = Enabled;
            // The menu controls
            mnuSaveROM.Enabled = Enabled;
            mnuCloseROM.Enabled = Enabled;
            mnuDistributeHack.Enabled = Enabled;
            mnuEnemyEditor.Enabled = Enabled;
            mnuFlagTSAEditor.Enabled = Enabled;
            mnuMapEditingMode.Enabled = Enabled;
            mnuObjectEditingMode.Enabled = Enabled;
            mnuPaletteEditor.Enabled = Enabled;
            mnuPlayerEditor.Enabled = Enabled;
            mnuTSAEditor.Enabled = Enabled;
            mnuViewEnemyStartPos.Enabled = Enabled;
            mnuViewFlag.Enabled = Enabled;
            mnuViewGridlines.Enabled = Enabled;
            mnuViewPlayerStartPos.Enabled = Enabled;
            // The toolbar controls
            tlbCloseROM.Enabled = Enabled;
            tlbEnemyEditor.Enabled = Enabled;
            tlbMapEditingMode.Enabled = Enabled;
            tlbObjectEditingMode.Enabled = Enabled;
            tlbPaletteEditor.Enabled = Enabled;
            tlbPlayerEditor.Enabled = Enabled;
            tlbSaveROM.Enabled = Enabled;
            tlbTSAEditor.Enabled = Enabled;
            tlbViewGridlines.Enabled = Enabled;
        }

        private void mnuOpenROM_Click(object sender, EventArgs e)
        {
            if (ofdOpenROM.ShowDialog() == DialogResult.OK)
            {
                LoadROM(ofdOpenROM.FileName);
            }
        }

        private void LoadROM(string filename)
        {
            BCData = new BattleCityData(filename, "Resources" + Path.DirectorySeparatorChar + "BattleCityJ.ini", "",
                "Resources" + Path.DirectorySeparatorChar);
            BCData.Level = 0;
            SetEnabledStatus(true);
            // Reset the editing mode to map editing mode.
            ChangeEditingMode(EditorSetting.MapEditingMode);
            // Reset the current tile.
            CurrentTile = 0;
            // Reset the current pattern table tile.
            CurTSATile = -1;
            // Set the window caption.
            SetWindowTitle();
            // Set the statusbar.
            lblDataFile.Text = "BattleCityJ.ini";
            lblDataFile.Image = new Bitmap(BCData.TypeIcon);

        }

        private void SetWindowTitle()
        {
            System.Text.StringBuilder TitleText = new System.Text.StringBuilder(Properties.Resources.ApplicationName);
            // Set the title caption.

            if (BCData != null)
            {
                TitleText.Append(" [" + Path.GetFileName(BCData.Filename) + "]");

                if (BCData.IsChanged)
                {
                    TitleText.Append(" *");
                }
            }

            // Set the window's text to whatever is in titletext
            Text = TitleText.ToString();

        }

        private void picLevel_Paint(object sender, PaintEventArgs e)
        {
            if (BCData != null)
            {
                Bitmap LevelDataBMP = new Bitmap(208, 208, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                BCData.DrawLevelData(ref LevelDataBMP, LevelDisplayFlag.ViewEnemy | LevelDisplayFlag.ViewPlayer | LevelDisplayFlag.ViewFortifiedFlag);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(LevelDataBMP, 0, 0, LevelDataBMP.Width * 2, LevelDataBMP.Height * 2);
            }
        }

        private void picTileSelector_Paint(object sender, PaintEventArgs e)
        {
            if (BCData != null)
            {
                Bitmap TilesBMP = new Bitmap(64, 256, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                BCData.DrawTileSelector(ref TilesBMP);
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(TilesBMP, 0, 0, TilesBMP.Width * 2, TilesBMP.Height * 2);
                int TempX, TempY;

                // Work out the current X, Y of the currently selected tile
                TempX = (CurrentTile % 2) * 32;
                TempY = (CurrentTile / 2) * 32;
                e.Graphics.DrawRectangle(new Pen(Brushes.Red, 2.0F), TempX, TempY, 32, 32);
            }
        }

        private void mnuCloseROM_Click(object sender, EventArgs e)
        {
            if (BCData != null)
            {
                BCData.Dispose();
                BCData = null;
                SetEnabledStatus(false);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuTSAEditor_Click(object sender, EventArgs e)
        {
            if (_TSA == null || CurTSATile == -1)
            {
                _TSA = new frmTSAEditor(ref BCData);
                _TSA.Show(this);
            }
        }

        private void mnuSaveROM_Click(object sender, EventArgs e)
        {
            if (BCData != null)
            {
                // Properties.Settings.Default.
                // Save the ROM Data.
                BCData.Save();
            }
        }

        private void PopulateRecentMenu()
        {
            ToolStripMenuItem mnu = new ToolStripMenuItem("test", null, mnuRecentFileClick);
            mnuFile.DropDownItems.Insert(7, mnu);
        }

        private void mnuRecentFileClick(object sender, EventArgs e)
        {
            MessageBox.Show((sender as ToolStripMenuItem).Text);
        }

        private void mnuMapEditingMode_Click(object sender, EventArgs e)
        {
            ChangeEditingMode(EditorSetting.MapEditingMode);
        }

        private void mnuObjectEditingMode_Click(object sender, EventArgs e)
        {
            ChangeEditingMode(EditorSetting.ObjectEditingMode);
        }

        /// <summary>
        /// Changes the editing mode, and changes the controls that represent the current
        /// status of the editing mode.
        /// </summary>
        /// <param name="mode">The editing mode to switch to.</param>
        private void ChangeEditingMode(EditorSetting mode)
        {
            if (mode == EditorSetting.MapEditingMode)
            {
                // Set the editing mode to ObjectEditingMode.
                _EditingMode = EditorSetting.MapEditingMode;
                // Now, set the checked status of the map editing mode controls
                mnuMapEditingMode.Checked = true;
                tlbMapEditingMode.Checked = true;
                // Now, reset the checked status of the object editing mode controls.
                mnuObjectEditingMode.Checked = false;
                tlbObjectEditingMode.Checked = false;
                // Set the text in the statusbar to whatever editing mode is being used.
                lblEditingMode.Text = Properties.Resources.MapEditingMode;
            }
            else if (mode == EditorSetting.ObjectEditingMode)
            {
                // Set the editing mode to ObjectEditingMode.
                _EditingMode = EditorSetting.ObjectEditingMode;
                // Now, reset the checked status of the map editing mode controls
                mnuMapEditingMode.Checked = false;
                tlbMapEditingMode.Checked = false;
                // Now, set the checked status of the object editing mode controls.
                mnuObjectEditingMode.Checked = true;
                tlbObjectEditingMode.Checked = true;
                // Set the text in the statusbar to whatever editing mode is being used.
                lblEditingMode.Text = Properties.Resources.ObjectEditingMode;
            }
            else if (mode == EditorSetting.None)
            {
                _EditingMode = EditorSetting.None;
                // Now, reset all the controls that store the current status.
                mnuMapEditingMode.Checked = false;
                tlbMapEditingMode.Checked = false;
                mnuObjectEditingMode.Checked = false;
                tlbObjectEditingMode.Checked = false;
                // Set the text in the statusbar to whatever editing mode is being used.
                lblEditingMode.Text = Properties.Resources.NoROMLoaded;
            }
        }

        private void picLevel_MouseDown(object sender, MouseEventArgs e)
        {
            // First, check that the ROM is loaded.
            if (BCData != null)
            {
                if (_EditingMode == EditorSetting.MapEditingMode)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // If the user clicked the left mouse button, change the 
                        // level data to the currently selected tile.
                        BCData.CurrentLevel.SetLevelData(e.Y / 32, e.X / 32, CurrentTile);
                        picLevel.Invalidate();
                        // Set the window title.
                        SetWindowTitle();
                    }
                    else
                    {
                        // Otherwise, if the user clicked the right mouse button, change
                        // the currently selected tile to the one underneath the mouse.
                        CurrentTile = BCData.CurrentLevel.GetLevelData(e.Y / 32, e.X / 32);
                    }
                }
                else if (_EditingMode == EditorSetting.ObjectEditingMode)
                {
                    _ObjUnderMouse = -1;
                    _MouseDown = true;
                    for (int i = 0; i < 5; i++)
                    {
                        if ((e.X / 32 == BCData.CurrentLevel.StartingPositions[i].X) && (e.Y / 32 == BCData.CurrentLevel.StartingPositions[i].Y))
                        {
                            _ObjUnderMouse = i;
                            break;
                        }
                    }

                }
            }
        }

        private void picTileSelector_MouseDown(object sender, MouseEventArgs e)
        {
            // First, check that the ROM is loaded.
            if (BCData != null)
            {
                CurrentTile = Convert.ToByte((e.X / 32) + ((e.Y / 32) * 2));

                if (CurTSATile > -1)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        int TileX1 = (e.X % 32);
                        int TileY1 = (e.Y % 32);
                        BCData.EditTSA(CurrentTile, Convert.ToByte(TileX1 / 16), Convert.ToByte(TileY1 / 16), Convert.ToByte(CurTSATile));
                        // Set the window title.
                        SetWindowTitle();
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        BCData.IncrementTileAttribute(CurrentTile);
                        // Set the window title.
                        SetWindowTitle();
                    }
                    picLevel.Invalidate();
                }
                picTileSelector.Invalidate();
            }

        }

        private void picLevel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_EditingMode == EditorSetting.MapEditingMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    BCData.CurrentLevel.SetLevelData(e.Y / 32, e.X / 32, this.CurrentTile);
                }
            }
            else if (_EditingMode == EditorSetting.ObjectEditingMode)
            {
                if ((_MouseDown == true) && (_ObjUnderMouse > -1) && (e.X <= picLevel.ClientRectangle.Width || e.Y <= picLevel.ClientRectangle.Height))
                {
                    // Temporarily cache the variables, and make sure that they are within the correct range.
                    int x, y;
                    x = e.X / 32;
                    y = e.Y / 32;

                    // If the x co-ordinate is somehow less than zero, change it to zero.
                    if (x < 0)
                        x = 0;
                    
                    // If the y co-ordinate is somehow less than zero, change it to zero.
                    if (y < 0)
                        y = 0;

                    if (BCData.CurrentLevel.StartingPositions[_ObjUnderMouse].X != (x))
                    {
                        BCData.CurrentLevel.StartingPositions[_ObjUnderMouse].X = Convert.ToByte(x);
                    }

                    if (BCData.CurrentLevel.StartingPositions[_ObjUnderMouse].Y != (y))
                    {
                        BCData.CurrentLevel.StartingPositions[_ObjUnderMouse].Y = Convert.ToByte(y);
                    }
                }

            }

            picLevel.Invalidate();
            SetWindowTitle();
        }

        private void picLevel_MouseUp(object sender, MouseEventArgs e)
        {
            // Reset the object handling variables.
            _MouseDown = false;
            _ObjUnderMouse = -1;
        }
    }
}
