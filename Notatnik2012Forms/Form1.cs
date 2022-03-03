using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotatnikPluginAPI;

namespace Notatnik2012Forms
{
    public partial class Form1 : Form
    {
        void DodajPozycjeMenu(string nazwaPozycji, string nazwaGrupy, string toolTip, EventHandler klik)
        {
            ToolStripMenuItem pozycja = new ToolStripMenuItem(nazwaPozycji);
            if (!string.IsNullOrEmpty(toolTip))
                pozycja.ToolTipText = toolTip;
                pozycja.Click += klik;

            ToolStripMenuItem grupa;
            if (menuStrip1.Items.ContainsKey(nazwaGrupy))
                grupa = (ToolStripMenuItem)menuStrip1.Items[nazwaGrupy];
            else
            {
                grupa = new ToolStripMenuItem(nazwaGrupy);
                grupa.Name = nazwaGrupy;
                menuStrip1.Items.Add(grupa);
            }
            grupa.DropDownItems.Add(pozycja);
        }
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DodajPozycjeMenu("wstaw godzinę", "czas", "wstawia aktualną godzinę z minutami", (x, y) => MessageBox.Show("godzina"));
            foreach(string plik in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll"))
            {
                Assembly asm = Assembly.LoadFrom(plik);
                foreach(Type typ in asm.GetTypes())
                {
                    foreach (MethodInfo funkcja in typ.GetMethods(BindingFlags.Public | BindingFlags.Static))
                    {
                        PozycjaMenuAttribute atrybut = funkcja.GetCustomAttribute<PozycjaMenuAttribute>();
                        if (atrybut != null)
                            {
                            DodajPozycjeMenu(atrybut.Tekst, atrybut.Grupa, atrybut.ToolTip, (x, y) => 
                            richTextBox1.SelectedText = (string)funkcja.Invoke(null, new object[] { richTextBox1.SelectedText }));
                            }
                    }
                }
            }
        }
    }
}
