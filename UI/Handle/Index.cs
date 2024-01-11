using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class FormMain : Form
    {
        
        private void handleClickPenButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 1;
                    a[tmp].isSelect = false;
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickEraseButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 15;
                    a[tmp].isSelect = false;
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }

                    // Tăng BorderThickness của button được click lên một giá trị nào đó
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickFillButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 6;
                    a[tmp].isSelect = false;
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickTextButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 16;
                    a[tmp].isText = true;
                    a[tmp].isSelect = false;
                    a[tmp].currShape = new Text();
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickEllipseButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 2;
                    a[tmp].isSelect = true;
                    a[tmp].currShape = new Ellipse();
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickLineButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 5;
                    a[tmp].isSelect = true;
                    a[tmp].currShape = new Line();
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickRectangleButton(object sender, EventArgs e)
        {

            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 7;
                    a[tmp].isSelect = true;
                    a[tmp].currShape=new HinhChuNhat();
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickTriangleButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 8;
                    a[tmp].isSelect = true;
                    a[tmp].currShape = new Triangle();
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickright_TriangleButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 9;
                    a[tmp].isSelect = true;
                    a[tmp].currShape = new RightTriangle();
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickHexagonButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 10;
                    a[tmp].isSelect = true;
                    a[tmp].currShape = new Hexagon();
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickArrowButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 11;
                    a[tmp].isSelect = true;
                    a[tmp].currShape = new Arrow();
                    
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickStarButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {
                    a[tmp].index = 12;
                    a[tmp].isSelect = true;
                    a[tmp].currShape = new Star();
                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleSelectButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                if (tmp < a.Count)
                {

                    a[tmp].index = 17;
                    a[tmp].currShape = new Select();
                    a[tmp].isSelect = false;

                    foreach (Guna2Button button in a[tmp].buttons)
                    {
                        button.BorderThickness = 0;
                        button.Refresh();
                    }
                    clickedButton.BorderThickness = 2;

                }
            }
        }
        private void handleClickSizeButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                ContextMenuStrip sizeMenu = new ContextMenuStrip();
                a[tmp].isSelect = false;

                // Create ToolStripMenuItems for different sizes
                ToolStripMenuItem pen = new ToolStripMenuItem();
                pen.DisplayStyle = ToolStripItemDisplayStyle.Text;
                pen.Text = "1px";
                ToolStripMenuItem smallSizeItem = new ToolStripMenuItem();
                smallSizeItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
                smallSizeItem.Text = "3px";
                ToolStripMenuItem mediumSizeItem = new ToolStripMenuItem();
                mediumSizeItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
                mediumSizeItem.Text = "5px";
                ToolStripMenuItem largeSizeItem = new ToolStripMenuItem();
                largeSizeItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
                largeSizeItem.Text = "8px";
                ToolStripMenuItem erase1 = new ToolStripMenuItem();
                erase1.DisplayStyle = ToolStripItemDisplayStyle.Text;
                erase1.Text = "15px";
                ToolStripMenuItem erase2 = new ToolStripMenuItem();
                erase2.DisplayStyle = ToolStripItemDisplayStyle.Text;
                erase2.Text = "20px";

                // Add event handlers for menu item clicks
                smallSizeItem.Click += SizeMenuItem_Click;
                mediumSizeItem.Click += SizeMenuItem_Click;
                largeSizeItem.Click += SizeMenuItem_Click;
                if (a[tmp].index == 1)
                {
                    pen.Click += SizeMenuItem_Click;
                    sizeMenu.Items.Add(pen);
                }
                // Add the ToolStripMenuItems to the dropdown menu
                sizeMenu.Items.Add(smallSizeItem);
                sizeMenu.Items.Add(mediumSizeItem);
                sizeMenu.Items.Add(largeSizeItem);
                if (a[tmp].index == 15)
                {
                    erase1.Click += SizeMenuItem_Click;
                    erase2.Click+=  SizeMenuItem_Click;
                    sizeMenu.Items.Add(erase1);
                    sizeMenu.Items.Add(erase2);
                }

                
                // Show the context menu at the button's location
                sizeMenu.Show(clickedButton, new Point(-15, clickedButton.Height));

            }
        }
        private void SizeMenuItem_Click(object sender, EventArgs e)
        {
            // Handle size selection here
            int tmp = tcMain.SelectedIndex;
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            if (clickedItem.Text == "3px")
                a[tmp].Pen.Width = 3f;
            if (clickedItem.Text == "5px")
                a[tmp].Pen.Width = 5f;
            if (clickedItem.Text == "8px")
                a[tmp].Pen.Width = 8f;
            if (a[tmp].index==15)
            {
                if(clickedItem.Text == "15px")
                    a[tmp].Eraser.Width = 15f;
                if (clickedItem.Text == "20px")
                    a[tmp].Eraser.Width = 15f;
            }
            if (a[tmp].index==1&&clickedItem.Text == "1px")
                a[tmp].Pen.Width = 1f;
            a[tmp].oPen.Width = a[tmp].Pen.Width;
            a[tmp].pictureBox.Refresh();

        }
        private void handleClickBrushButton(object sender, EventArgs e)
        {
            if (sender is Guna2Button clickedButton)
            {
                int tmp = tcMain.SelectedIndex;
                a[tmp].isSelect = false;
                ContextMenuStrip brushMenu = new ContextMenuStrip();
                

                // Create ToolStripMenuItems for different sizes
                ToolStripMenuItem brush1Item = new ToolStripMenuItem(Properties.Resources.icons8_horizontal_line_50);
                ToolStripMenuItem brush2Item = new ToolStripMenuItem(Properties.Resources.icons8_dashed_line_48);
                ToolStripMenuItem brush3Item = new ToolStripMenuItem(Properties.Resources.icons8_ellipsis_48);
                // Set DisplayStyle to show only the image
                brush1Item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                brush1Item.Text = "Solid";
                brush2Item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                brush2Item.Text = "Dash";
                brush3Item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                brush3Item.Text = "Dot";
                
                

                // Add event handlers for menu item clicks
                brush1Item.Click += BrushMenuItem_Click;
                brush2Item.Click += BrushMenuItem_Click;
                brush3Item.Click += BrushMenuItem_Click;

               
                // Add the ToolStripMenuItems to the dropdown menu
                brushMenu.Items.Add(brush1Item);
                brushMenu.Items.Add(brush2Item);
                brushMenu.Items.Add(brush3Item);
                
                // Show the context menu at the button's location
                brushMenu.Show(clickedButton, new Point(-15, clickedButton.Height));
            }
        }
        private void BrushMenuItem_Click(object sender, EventArgs e)
        {
            int tmp = tcMain.SelectedIndex;
            a[tmp].isSelect = false;
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            if (clickedItem.Text == "Solid")
                a[tmp].Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            if (clickedItem.Text == "Dash")
                a[tmp].Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            if (clickedItem.Text == "Dot")
                a[tmp].Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            a[tmp].pictureBox.Refresh();
        }
    }
}
