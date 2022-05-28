using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public int gridx = 0;
        public int gridy = 0;
        public int size = 10;
        public int minesnum = 10;
        void CreatePanel(int x, int y, string id)
        {
            Panel newpanel = new Panel();
            newpanel.Visible = true;
            newpanel.BackColor = Color.Gray;
            newpanel.Location = new Point(gridx, gridy);
            newpanel.Size = new Size(35, 35);
            newpanel.Name = id;
            
            newpanel.MouseClick += Newpanel_MouseClick;
            this.Controls.Add(newpanel);
            

        }
        public int[,] grid = new int[1000,1000];
        void CreateGrid(int size)
        {
            for (int i = 1; i < size+1; i++)
            {
                for (int j = 1; j < size+1; j++)
                {
                    string id = j + ";" + i + ";" + 0;
                    CreatePanel(gridx, gridy, id);
                    gridx += 36;
                    

                    grid[j,i] = 0;
                }
                gridy += 36;
                gridx = 0;
            }
            CreateMines();
            
            
            
        }
        void CreateMines()
        {
            int minescreated = minesnum;
            while (minescreated > 0)
            {
                Random rng = new Random();
                int x = rng.Next(1, size);
                System.Threading.Thread.Sleep(1);
                int y = rng.Next(1, size);
                if (grid[x, y] != -1)
                {
                    grid[x, y] = -1;
                    GetNeighbors(x, y);
                    minescreated--;
                    
                }
                System.Threading.Thread.Sleep(1);

            }
        }
        
        void GetNeighbors(int minex, int miney)
        {
            if (grid[minex - 1, miney] != null)
            {
                if (grid[minex - 1, miney] != -1)
                {
                    grid[minex - 1, miney]++;
                }   
            }
            if (grid[minex + 1, miney] != null)
            {
                if (grid[minex + 1, miney] != -1)
                {
                    grid[minex + 1, miney]++;
                }
            }
            if (grid[minex, miney - 1] != null)
            {
                if (grid[minex, miney - 1] != -1)
                {
                    grid[minex, miney - 1]++;
                }
            }
            if (grid[minex, miney + 1] != null)
            {
                if (grid[minex, miney + 1] != -1)
                {
                    grid[minex, miney + 1]++;
                }
            }
            //diagonals
            if (grid[minex- 1, miney - 1] != null)
            {
                if (grid[minex- 1, miney - 1] != -1)
                {
                    grid[minex - 1, miney - 1]++;
                }
            }
            if (grid[minex + 1, miney - 1] != null)
            {
                if (grid[minex + 1, miney - 1] != -1)
                {
                    grid[minex + 1, miney - 1]++;
                }
            }
            if (grid[minex - 1, miney + 1] != null)
            {
                if (grid[minex - 1, miney + 1] != -1)
                {
                    grid[minex - 1, miney + 1]++;
                }
            }
            if (grid[minex + 1, miney + 1] != null)
            {
                if (grid[minex + 1, miney + 1] != -1)
                {
                    grid[minex + 1, miney + 1]++;
                }
            }

        }
        
        Tuple<int,int> GetCellID(string id)
        {
            string[] split = id.Split(';');
            int[] xy = new int[3];
            xy[0] = Convert.ToInt32(split[0]);
            xy[1] = Convert.ToInt32(split[1]);
            return Tuple.Create(xy[0],xy[1]);
        }
        int clickedcells = 0;
        
        void ClickedZero(int minex, int miney, int oldx, int oldy)
        {
            
            if (grid[minex - 1, miney] != null)
            {
                
                    if (grid[minex - 1, miney] == 0)
                    {
                        try
                        {
                            Panel clickedpanel = new Panel();
                            for (int i = 0; i < Controls.Count; i++)
                            {
                                if (Controls[i].Name.Contains(";"))
                                {
                                    string[] splitter = Controls[i].Name.Split(';');
                                    if (Convert.ToInt32(splitter[0]) == minex - 1 && Convert.ToInt32(splitter[1]) == miney)
                                    {
                                        clickedpanel = (Panel)Controls[i];
                                    }
                                }
                            }
                            if (clickedpanel.BackColor == Color.Gray)
                            {
                                clickedpanel.BackColor = Color.Black;
                                clickedpanel.Controls.Clear();
                                Label lbl = new Label();
                                string[] split = clickedpanel.Name.Split(';');
                                lbl.Name = (minex - 1) + "`" + miney;
                                lbl.Text = split[2];
                                lbl.Location = new Point(10, 10);
                                lbl.Visible = true;
                                lbl.ForeColor = Color.White;
                                clickedpanel.Controls.Add(lbl);
                                UpdateText();
                                clickedcells++;
                            if (firstzero == true)
                            {
                                firstzero = false;
                                clickedcells--;
                            }
                            ClickedZero(minex + 1, miney, minex, miney);
                            }

                        }
                        catch (Exception _)
                        {

                        }

                    }
                
            }
            if (grid[minex + 1, miney] != null)
            {
                
                    if (grid[minex + 1, miney] == 0)
                    {
                        try
                        {
                            Panel clickedpanel = new Panel();
                            for (int i = 0; i < Controls.Count; i++)
                            {
                                if (Controls[i].Name.Contains(";"))
                                {
                                    string[] splitter = Controls[i].Name.Split(';');
                                    if (Convert.ToInt32(splitter[0]) == minex + 1 && Convert.ToInt32(splitter[1]) == miney)
                                    {
                                        clickedpanel = (Panel)Controls[i];
                                    }
                                }
                            }
                            if (clickedpanel.BackColor == Color.Gray)
                            {
                                clickedpanel.BackColor = Color.Black;
                                clickedpanel.Controls.Clear();
                                Label lbl = new Label();
                                string[] split = clickedpanel.Name.Split(';');
                                lbl.Name = (minex + 1) + "`" + miney;
                                lbl.Text = split[2];
                                lbl.Location = new Point(10, 10);
                                lbl.Visible = true;
                                lbl.ForeColor = Color.White;
                                clickedpanel.Controls.Add(lbl);
                                UpdateText();
                                clickedcells++;
                            if (firstzero == true)
                            {
                                firstzero = false;
                                clickedcells--;
                            }
                            ClickedZero(minex + 1, miney, minex, miney);
                            }
                        }
                        catch (Exception _)
                        {

                        }

                    }
                
            }
            if (grid[minex, miney - 1] != null)
            {
                
                    if (grid[minex, miney-1] == 0)
                    {
                        try
                        {
                            Panel clickedpanel = new Panel();
                            for (int i = 0; i < Controls.Count; i++)
                            {
                                if (Controls[i].Name.Contains(";"))
                                {
                                    string[] splitter = Controls[i].Name.Split(';');
                                    if (Convert.ToInt32(splitter[0]) == minex && Convert.ToInt32(splitter[1]) == miney - 1)
                                    {
                                        clickedpanel = (Panel)Controls[i];
                                    }
                                }
                            }
                            if (clickedpanel.BackColor == Color.Gray)
                            {
                                clickedpanel.BackColor = Color.Black;
                                clickedpanel.Controls.Clear();
                                Label lbl = new Label();
                                string[] split = clickedpanel.Name.Split(';');
                                lbl.Name = minex + "`" + (miney - 1);
                                lbl.Text = split[2];
                                lbl.Location = new Point(10, 10);
                                lbl.Visible = true;
                                lbl.ForeColor = Color.White;
                                clickedpanel.Controls.Add(lbl);
                                UpdateText();
                                clickedcells++;
                            if (firstzero == true)
                            {
                                firstzero = false;
                                clickedcells--;
                            }
                            ClickedZero(minex, miney - 1, minex, miney);
                            }
                        }
                        catch (Exception _)
                        {

                        }

                    }
                
            }
            if (grid[minex, miney + 1] != null)
            {
                
                    if (grid[minex, miney + 1] == 0)
                    {
                        try
                        {
                            Panel clickedpanel = new Panel();
                            for (int i = 0; i < Controls.Count; i++)
                            {
                                if (Controls[i].Name.Contains(";"))
                                {
                                    string[] splitter = Controls[i].Name.Split(';');
                                    if (Convert.ToInt32(splitter[0]) == minex && Convert.ToInt32(splitter[1]) == miney + 1)
                                    {
                                        clickedpanel = (Panel)Controls[i];
                                    }
                                }
                            }
                            if (clickedpanel.BackColor == Color.Gray)
                            {
                                clickedpanel.BackColor = Color.Black;
                                clickedpanel.Controls.Clear();
                                Label lbl = new Label();
                                string[] split = clickedpanel.Name.Split(';');
                                lbl.Name = minex + "`" + (miney + 1);
                                lbl.Text = split[2];
                                lbl.Location = new Point(10, 10);
                                lbl.Visible = true;
                                lbl.ForeColor = Color.White;
                                clickedpanel.Controls.Add(lbl);
                                UpdateText();
                                clickedcells++;
                            if (firstzero == true)
                            {
                                firstzero = false;
                                clickedcells--;
                            }
                            ClickedZero(minex, miney + 1, minex, miney);
                            }
                        }
                        catch (Exception _)
                        {

                        }
                    }
                
            }
            //diagonals
            if (grid[minex - 1, miney - 1] != null)
            {
                
                    if (grid[minex - 1, miney - 1] == 0)
                    {
                        try
                        {
                            Panel clickedpanel = new Panel();
                            for (int i = 0; i < Controls.Count; i++)
                            {
                                if (Controls[i].Name.Contains(";"))
                                {
                                    string[] splitter = Controls[i].Name.Split(';');
                                    if (Convert.ToInt32(splitter[0]) == minex - 1 && Convert.ToInt32(splitter[1]) == miney - 1)
                                    {
                                        clickedpanel = (Panel)Controls[i];
                                    }
                                }

                            }
                            if (clickedpanel.BackColor == Color.Gray)
                            {
                                clickedpanel.BackColor = Color.Black;
                                clickedpanel.Controls.Clear();
                                Label lbl = new Label();
                                string[] split = clickedpanel.Name.Split(';');
                                lbl.Name = (minex - 1) + "`" + (miney - 1);
                                lbl.Text = split[2];
                                lbl.Location = new Point(10, 10);
                                lbl.Visible = true;
                                lbl.ForeColor = Color.White;
                                clickedpanel.Controls.Add(lbl);
                                UpdateText();
                                clickedcells++;
                            if (firstzero == true)
                            {
                                firstzero = false;
                                clickedcells--;
                            }
                            ClickedZero(minex - 1, miney - 1, minex, miney);
                            }
                        }
                        catch (Exception _)
                        {

                        }
                    }
                
            }
            if (grid[minex + 1, miney - 1] != null)
            {
                
                    if (grid[minex + 1, miney - 1] == 0)
                    {
                        try
                        {
                            Panel clickedpanel = new Panel();
                            for (int i = 0; i < Controls.Count; i++)
                            {
                                if (Controls[i].Name.Contains(";"))
                                {
                                    string[] splitter = Controls[i].Name.Split(';');
                                    if (Convert.ToInt32(splitter[0]) == minex + 1 && Convert.ToInt32(splitter[1]) == miney - 1)
                                    {
                                        clickedpanel = (Panel)Controls[i];
                                    }
                                }
                            }
                            if (clickedpanel.BackColor == Color.Gray)
                            {
                                clickedpanel.BackColor = Color.Black;
                                clickedpanel.Controls.Clear();
                                Label lbl = new Label();
                                string[] split = clickedpanel.Name.Split(';');
                                lbl.Name = (minex + 1) + "`" + (miney - 1);
                                lbl.Text = split[2];
                                lbl.Location = new Point(10, 10);
                                lbl.Visible = true;
                                lbl.ForeColor = Color.White;
                                clickedpanel.Controls.Add(lbl);
                                UpdateText();
                                clickedcells++;
                            if (firstzero == true)
                            {
                                firstzero = false;
                                clickedcells--;
                            }
                            ClickedZero(minex + 1, miney - 1, minex, miney);
                            }
                        }
                        catch (Exception _)
                        {

                        }
                    }
                
            }
            if (grid[minex - 1, miney + 1] != null)
            {
                
                    if (grid[minex - 1, miney + 1] == 0)
                    {
                        try
                        {
                            Panel clickedpanel = new Panel();
                            for (int i = 0; i < Controls.Count; i++)
                            {
                                if (Controls[i].Name.Contains(";"))
                                {
                                    string[] splitter = Controls[i].Name.Split(';');
                                    if (Convert.ToInt32(splitter[0]) == minex - 1 && Convert.ToInt32(splitter[1]) == miney + 1)
                                    {
                                        clickedpanel = (Panel)Controls[i];
                                    }
                                }
                            }
                            if (clickedpanel.BackColor == Color.Gray)
                            {
                                clickedpanel.BackColor = Color.Black;
                                clickedpanel.Controls.Clear();
                                Label lbl = new Label();
                                string[] split = clickedpanel.Name.Split(';');
                                lbl.Name = (minex - 1) + "`" + (miney + 1);
                                lbl.Text = split[2];
                                lbl.Location = new Point(10, 10);
                                lbl.Visible = true;
                                lbl.ForeColor = Color.White;
                                clickedpanel.Controls.Add(lbl);
                                UpdateText();
                                clickedcells++;
                            if (firstzero == true)
                            {
                                firstzero = false;
                                clickedcells--;
                            }
                            ClickedZero(minex - 1, miney + 1, minex, miney);
                            }
                        }
                        catch (Exception _)
                        {

                        }
                    }
                
            }
            if (grid[minex + 1, miney + 1] != null)
            {
                
                    if (grid[minex + 1, miney + 1] == 0)
                    {
                        try
                        {
                            Panel clickedpanel = new Panel();
                            for (int i = 0; i < Controls.Count; i++)
                            {
                                if (Controls[i].Name.Contains(";"))
                                {
                                    string[] splitter = Controls[i].Name.Split(';');
                                    if (Convert.ToInt32(splitter[0]) == minex + 1 && Convert.ToInt32(splitter[1]) == miney + 1)
                                    {
                                        clickedpanel = (Panel)Controls[i];
                                    }
                                }
                            }
                            if (clickedpanel.BackColor == Color.Gray)
                            {
                                clickedpanel.BackColor = Color.Black;
                                clickedpanel.Controls.Clear();
                                Label lbl = new Label();
                                string[] split = clickedpanel.Name.Split(';');
                                lbl.Name = (minex + 1) + "`" + (miney + 1);
                                lbl.Text = split[2];
                                lbl.Location = new Point(10, 10);
                                lbl.Visible = true;
                                lbl.ForeColor = Color.White;
                                clickedpanel.Controls.Add(lbl);
                                UpdateText();
                                clickedcells++;
                            if (firstzero == true)
                            {
                                firstzero = false;
                                clickedcells--;
                            }
                            ClickedZero(minex + 1, miney + 1, minex, miney);
                                
                                

                        }
                        }
                        catch (Exception _)
                        {

                        }
                    }
                
            }
            
           
        }
        public int flagsclicked = 0;
        public bool firstzero = true;
        private void Newpanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                

                Panel clickedpanel = (Panel)sender;
                Tuple<int, int> id = GetCellID(clickedpanel.Name);
                
                if (clickedpanel.BackColor != Color.Blue && clickedpanel.BackColor != Color.Black)
                {
                    if (grid[id.Item1, id.Item2] != -1)
                    {
                        if (grid[id.Item1, id.Item2] == 0)
                        {
                            firstzero = true;
                            ClickedZero(id.Item1, id.Item2, id.Item1, id.Item2);
                        }
                        clickedpanel.BackColor = Color.Black;
                        clickedpanel.Controls.Clear();
                        Label lbl = new Label();
                        string[] split = clickedpanel.Name.Split(';');
                        lbl.Name = id.Item1 + "`" + id.Item2;
                        lbl.Text = split[2];
                        lbl.Location = new Point(10, 10);
                        lbl.Visible = true;
                        lbl.ForeColor = Color.White;
                        clickedpanel.Controls.Add(lbl);
                        UpdateText();
                        clickedcells++;
                        label1.Text = "Clicked Cells: " + clickedcells; 
                        if (clickedcells == size*size-minesnum)
                        {
                            OpenAll();
                            DialogResult dr = MessageBox.Show("You found all the bombs! Do you want to try again?", "Game State", MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes)
                            {

                                Form1 newgame = new Form1();
                                newgame.Show();
                                this.Hide();
                            }
                            else
                            {
                                Application.Exit();
                            }
                        } 
                    }
                    else
                    {
                        clickedcells = 0;
                        clickedpanel.BackColor = Color.Red;
                        OpenAll();
                        DialogResult dr = MessageBox.Show("You lose! Do you want to try again?", "Game State", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            clickedcells = 0;
                            Form1 newgame = new Form1();
                            newgame.Show();
                            this.Hide();
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                   
                }
                
            }
            else
            {
                Panel clickedpanel = (Panel)sender;
                Tuple<int, int> id = GetCellID(clickedpanel.Name);
                if (clickedpanel.BackColor == Color.Blue)
                {
                    clickedpanel.BackColor = Color.Gray;
                    flagsclicked--;
                    if (grid[id.Item1, id.Item2] == -1)
                    {
                        correctflags--;
                    }
                }
                else if (clickedpanel.BackColor == Color.Gray)
                {
                    clickedpanel.BackColor = Color.Blue;
                    flagsclicked++;
                    if (grid[id.Item1, id.Item2] == -1)
                    {
                        correctflags++;
                    }
                }
                if (correctflags == 10)
                {
                    OpenAll();
                    DialogResult dr = MessageBox.Show("You flagged all the bombs! Do you want to try again?", "Game State", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        
                        Form1 newgame = new Form1();
                        newgame.Show();
                        this.Hide();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                label2.Text = "Bombs Flagged: " + flagsclicked + "/" + minesnum;
            }
            
        }
        public int correctflags = 0;
        public Form1()
        {
            InitializeComponent();
            CreateGrid(size);
            

        }
        void UpdateText()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].Name.Contains(";"))
                {
                    for (int k = 0; k < Controls[i].Controls.Count; k++)
                    {
                        if (Controls[i].Controls[k].Name.Contains("`"))
                        {
                            string[] split = Controls[i].Controls[k].Name.Split('`');
                            int[] xy = new int[3];
                            xy[0] = Convert.ToInt32(split[0]);
                            xy[1] = Convert.ToInt32(split[1]);
                            Tuple<int, int> id = Tuple.Create(xy[0], xy[1]);
                            if (grid[id.Item1, id.Item2] == 0)
                            {
                                Controls[i].Controls.Clear();
                            }
                            else
                            {
                                
                                
                                Controls[i].Controls[k].Text = grid[id.Item1, id.Item2] + "";
                            }
                            
                            
                            
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenAll();
        }


        void OpenAll()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].Name.Contains(";"))
                {
                    Tuple<int, int> id = GetCellID(Controls[i].Name);

                    if (grid[id.Item1, id.Item2] != -1)
                    {
                        Controls[i].BackColor = Color.Black;
                        Controls[i].Controls.Clear();
                        Label lbl = new Label();
                        string[] split = Controls[i].Name.Split(';') ;
                        lbl.Name = id.Item1 + "`" + id.Item2;
                        lbl.Text = split[2];
                        lbl.Location = new Point(10, 10);
                        lbl.Visible = true;
                        lbl.ForeColor = Color.White;
                        Controls[i].Controls.Add(lbl);
                        UpdateText();
                    }
                    else
                    {
                        Controls[i].BackColor = Color.Red;
                    }
                }
            }
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit
               ();
        }
    }
}
