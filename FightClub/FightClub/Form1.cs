using System;
using System.Windows.Forms;

namespace FightClub
{
    public partial class Form1 : Form
    {
        static Player existance;
        static User user = new User();
        static Pc enemy = new Pc();
        static Random randomGenerator;
        static int roundCounter = 1 ;
        BodyParts attacked = 0;

        public Form1()
        {
            
            InitializeComponent();
            richTextBox1.Text += "\nRound #" + roundCounter + ": ";
            Initialize("Player1","Player2");

        }
        public Form1(string name)
        {
            InitializeComponent();
            richTextBox1.Text += "\nRound #" + roundCounter + ": ";
            Initialize(name,"Player2");

        }
        public Form1(string name, string pcname)
        {
            InitializeComponent();
            richTextBox1.Text += "\nRound #" + roundCounter + ": ";
            Initialize(name,pcname);

        }
        public void Initialize(string name, string pcname)
        {
            randomGenerator = new Random((int)DateTime.UtcNow.Ticks);
            user = new User(name);
            enemy = new Pc(pcname);
            roundCounter = 1;
            label1.Text = user.Name;
            label2.Text = enemy.Name;
            label4.Text = user.Hp.ToString();
            label5.Text = enemy.Hp.ToString();
            progressBar1.Value = user.Hp;
            progressBar2.Value = enemy.Hp;
            user.Block += BlockEvent;
            user.Wound += WoundEvent;
            user.Death += DeathEvent;
            enemy.Block += BlockEvent;
            enemy.Wound += WoundEvent;
            enemy.Death += DeathEvent;
        }
        public void gameOver()
        {
            user.Block -= BlockEvent;
            user.Wound -= WoundEvent;
            user.Death -= DeathEvent;
            enemy.Block -= BlockEvent;
            enemy.Wound -= WoundEvent;
            enemy.Death -= DeathEvent;
            if (user.Hp < enemy.Hp)
            {
                progressBar1.Value = 0;
                label5.Text = "0";
            }
            else
            {
                progressBar2.Value = 0;
                label4.Text = "0";
            }
            button1.Hide();
        }
        string getBodyParts(BodyParts part)
        {
            switch (part)
            {
                case BodyParts.Head: return "голову ";
                case BodyParts.Body: return "тело ";
                case BodyParts.Legs: return "ноги ";
                default: return "Error 404";             }
        }
        void Attack(Player ex)
        {
            Array bodyParts = Enum.GetValues(typeof(BodyParts));

            if (ex is User)
            {
                attacked = (BodyParts)bodyParts.GetValue(randomGenerator.Next(1, 3));
                if (radioButton1.Checked)
                {
                    ex.setBlock(BodyParts.Head);
                }
                if (radioButton2.Checked)
                {
                    ex.setBlock(BodyParts.Body);
                }
                if (radioButton3.Checked)
                {
                    ex.setBlock(BodyParts.Legs);
                }
            }
            else
            {
                if (radioButton1.Checked)
                {
                    attacked = BodyParts.Head;
                }
                if (radioButton2.Checked)
                {
                    attacked = BodyParts.Body;
                }
                if (radioButton3.Checked)
                {
                    attacked = BodyParts.Legs;
                }
                ex.setBlock((BodyParts)bodyParts.GetValue(randomGenerator.Next(1, 3)));

            }
            BattleEventArgs e = new BattleEventArgs(ex.Name,ex.Hp);
            ex.getHit(attacked,e);
        }
        private void BlockEvent(object sender, BattleEventArgs e)
        {
            richTextBox1.Text += e.name + " успешно отбил атаку";
        }
        private void DeathEvent(object sender, BattleEventArgs e)
        {
            richTextBox1.Text += e.name + " погиб\n";
            gameOver();
        }

        private void WoundEvent(object sender, BattleEventArgs e)
        {
            if (existance is User)
            {   
                progressBar1.Value = e.hp;
                label5.Text= e.hp.ToString();

            }
            else
            {
                progressBar2.Value = e.hp;
                label4.Text = e.hp.ToString();
            }
            richTextBox1.Text += e.name + " получает ранение в " + getBodyParts(attacked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (existance is Pc)
            {
                label3.Text = "Attack : ";
                existance = user;
                Attack(existance);
            } 
            else 
            {
                label3.Text = "Defend : ";
                existance = enemy;
                Attack(existance);
            }
            roundCounter += 1;
            richTextBox1.Text += "\nRound #" + roundCounter + ": " ;
        }
    }
}
