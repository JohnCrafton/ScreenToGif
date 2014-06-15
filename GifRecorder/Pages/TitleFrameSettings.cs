﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenToGif.Pages
{
    public partial class TitleFrameSettings : Form
    {
        #region Variables

        private Color _colorBackground;
        private Font _font;
        private string _content;
        private Color _colorForeground;
        private bool _blured;

        #endregion

        #region Getter/Setter

        /// <summary>
        /// The Background Color.
        /// </summary>
        public Color ColorBackground
        {
            get { return _colorBackground; }
            set { _colorBackground = value; }
        }

        /// <summary>
        /// The selected Font of the text.
        /// </summary>
        public Font FontTitle
        {
            get { return _font; }
            set { _font = value; }
        }

        /// <summary>
        /// The Text typed by the user.
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        /// <summary>
        /// The Foreground color of the text.
        /// </summary>
        public Color ColorForeground
        {
            get { return _colorForeground; }
            set { _colorForeground = value; }
        }

        /// <summary>
        /// True if background should be a blured copy of the next frame. (Warning, if there is no next frame!)
        /// </summary>
        public bool Blured
        {
            get { return _blured; }
            set { _blured = value; }
        }

        #endregion

        /// <summary>
        /// Creates a Title Frame.
        /// </summary>
        public TitleFrameSettings(Bitmap bitmap = null)
        {
            InitializeComponent();
            
            //Shows the current Font.
            lblFont.Text = fontDialog.Font.Name + "; " + fontDialog.Font.SizeInPoints + "pt";
            pbForeColor.BackColor = fontDialog.Color;

            //Sets the example text and gives selction to it.
            tbTitle.Text = global::ScreenToGif.Properties.Resources.Label_TitleContent;
            tbTitle.Select();

            //Gets the current default values.
            this.FontTitle = fontDialog.Font;
            this.ColorBackground = colorDialog.Color;
            this.ColorForeground = fontDialog.Color;
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.ColorBackground = colorDialog.Color;
                pbBackground.BackColor = colorDialog.Color;

                pbExample.BackColor = colorDialog.Color;
                lblExample.BackColor = colorDialog.Color;
            }
            
        }

        private void pbBackground_MouseHover(object sender, EventArgs e)
        {
            if (pbBackground.BackColor.IsNamedColor)
            {
                tooltip.Show(pbBackground.BackColor.Name, pbBackground, 2000);
            }
        }

        private void rbSolidColor_CheckedChanged(object sender, EventArgs e)
        {
            pbBackground.Enabled = rbSolidColor.Checked;
            btnBackColor.Enabled = rbSolidColor.Checked;

            pbExample.Visible = rbSolidColor.Checked;
            lblExample.Visible = rbSolidColor.Checked;

            Blured = rbBlured.Checked;
        }

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.FontTitle = fontDialog.Font;
                this.ColorForeground = fontDialog.Color;
                lblFont.Text = fontDialog.Font.Name + "; " + fontDialog.Font.Size + "pt";

                pbForeColor.BackColor = fontDialog.Color;

                lblExample.ForeColor = fontDialog.Color;
                lblExample.Font = fontDialog.Font;
            }
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            this.Content = tbTitle.Text;
        }

        private void pbForeColor_MouseHover(object sender, EventArgs e)
        {
            if (pbForeColor.BackColor.IsNamedColor)
            {
                tooltip.Show(pbForeColor.BackColor.Name, pbForeColor, 2000);
            }
        }
    }
}