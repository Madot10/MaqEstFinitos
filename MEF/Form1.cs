using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MEF
{
    
    public class Form1 : Form
    {
        private MainMenu mainMenu1;
        private MenuItem menuItem1;
        private MenuItem mnuSalir;
        private MenuItem menuItem3;
        private MenuItem mnuInicio;
        private MenuItem mnuParo;
        private Timer timer1;
        private IContainer components;

        private Image dron;

        // Creamos un objeto para la maquina de estados finitos
        private CMaquina maquina = new CMaquina();

        // Objetos necesarios
        public S_objeto[] ListaObjetos = new S_objeto[10];
        public S_objeto MiBateria;
        public S_objeto EstacionCentral;
        private Label label1;
        private Label lb_estado;
        private Label lb_energia;

        //Salto de frames
        private int iskip = 0;

        public Form1()
        {
            //
            // Necesario para admitir el Dise�ador de Windows Forms
            //
            InitializeComponent();

            //
            // TODO: agregar c�digo de constructor despu�s de llamar a InitializeComponent
            //

            // Inicializamos los objetos

            //dron = Image.FromFile(Properties.Resources.drone);

            // Cremos un objeto para tener valores aleatorios
            Random random = new Random();

            // Recorremos todos los objetos
            for (int n = 0; n < 10; n++)
            {
                // Colocamos las coordenadas
                ListaObjetos[n].x = random.Next(0, 639);
                ListaObjetos[n].y = random.Next(0, 479);

                // Lo indicamos activo
                ListaObjetos[n].activo = true;

                //No esperando
                ListaObjetos[n].esperando = false;
            }

            // Colocamos la bateria
            MiBateria.x = random.Next(0, 639);
            MiBateria.y = random.Next(0, 479);
            MiBateria.activo = true;

            EstacionCentral.x = 319;
            EstacionCentral.y = 239;
            EstacionCentral.activo = true;

            maquina.Inicializa(ref ListaObjetos, MiBateria, EstacionCentral);


        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region C�digo generado por el Dise�ador de Windows Forms
        /// <summary>
        /// M�todo necesario para admitir el Dise�ador. No se puede modificar
        /// el contenido del m�todo con el editor de c�digo.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuInicio = new System.Windows.Forms.MenuItem();
            this.mnuParo = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lb_estado = new System.Windows.Forms.Label();
            this.lb_energia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuSalir});
            this.menuItem1.Text = "Archivo";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Index = 0;
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuInicio,
            this.mnuParo});
            this.menuItem3.Text = "Aplicacion";
            // 
            // mnuInicio
            // 
            this.mnuInicio.Index = 0;
            this.mnuInicio.Text = "Inicio";
            this.mnuInicio.Click += new System.EventHandler(this.mnuInicio_Click);
            // 
            // mnuParo
            // 
            this.mnuParo.Index = 1;
            this.mnuParo.Text = "Paro";
            this.mnuParo.Click += new System.EventHandler(this.mnuParo_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 35;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estado:";
            // 
            // lb_estado
            // 
            this.lb_estado.AutoSize = true;
            this.lb_estado.Location = new System.Drawing.Point(88, 12);
            this.lb_estado.Name = "lb_estado";
            this.lb_estado.Size = new System.Drawing.Size(14, 13);
            this.lb_estado.TabIndex = 2;
            this.lb_estado.Text = "A";
            // 
            // lb_energia
            // 
            this.lb_energia.AutoSize = true;
            this.lb_energia.Location = new System.Drawing.Point(88, 40);
            this.lb_energia.Name = "lb_energia";
            this.lb_energia.Size = new System.Drawing.Size(0, 13);
            this.lb_energia.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1081, 491);
            this.Controls.Add(this.lb_energia);
            this.Controls.Add(this.lb_estado);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Maquina de estados finitos";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// Punto de entrada principal de la aplicaci�n.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void mnuSalir_Click(object sender, System.EventArgs e)
        {
            // Cerramos la ventana y finalizamos la aplicacion
            this.Close();
        }

        private void mnuInicio_Click(object sender, System.EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void mnuParo_Click(object sender, System.EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            // Esta funcion es el handler del timer
            // Aqui tendremos la logica para actualizar nuestra maquina de estados

            // Actualizamos a la maquina
            maquina.Control();

            // Mandamos a redibujar la pantalla
            this.Invalidate();
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Creamos la fuente y la brocha para el texto
            Font fuente = new Font("Arial", 24);
            SolidBrush brocha = new SolidBrush(Color.Black);

            // Dibujamos el robot
            if (maquina.EstadoM == (int)CMaquina.estados.MUERTO)
                e.Graphics.DrawImage(Properties.Resources.explosion, maquina.CoordX - 4, maquina.CoordY - 4, 40, 40);
            else 
                e.Graphics.DrawImage(Properties.Resources.drone, maquina.CoordX-10, maquina.CoordY-10, 40, 40);
                //e.Graphics.DrawRectangle(Pens.Green, maquina.CoordX - 4, maquina.CoordY - 4, 20, 20);

            // Dibujamos los objetos
            for (int n = 0; n < 10; n++)
                if (ListaObjetos[n].activo == true && ListaObjetos[n].esperando == false)
                    e.Graphics.DrawImage(Properties.Resources.pizza, ListaObjetos[n].x , ListaObjetos[n].y , 30, 30);
                else if (ListaObjetos[n].esperando == true)
                    e.Graphics.DrawImage(Properties.Resources.reloj, ListaObjetos[n].x, ListaObjetos[n].y, 30, 30);
            //e.Graphics.DrawRectangle(Pens.Indigo, ListaObjetos[n].x - 4, ListaObjetos[n].y - 4, 20, 20);

            // Dibujamos la bateria
            e.Graphics.DrawImage(Properties.Resources.solar_panel, MiBateria.x - 4, MiBateria.y - 4, 50, 50);

            // Dibujamos la Estacion Central
            e.Graphics.DrawImage(Properties.Resources._base, EstacionCentral.x - 4, EstacionCentral.y - 4, 30, 30);

            if(iskip == 4)
            {
                // Indicamos el estado en que se encuentra la maquina
                lb_estado.Text = maquina.EstadoM.ToString();
                
                iskip = 0;
            }

            //Ver carga de bateria en interfaz
            //lb_energia.Text = maquina.EnergiaM.ToString();

            iskip++;

        }

  
    }
}
