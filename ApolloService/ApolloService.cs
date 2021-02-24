using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ApolloService
{
    public partial class ApolloService : ServiceBase
    {
        public ApolloService()
        {
            InitializeComponent();
        }

        //What the service does on start
        protected override void OnStart(string[] args)
        {
            PollSong();
        }

        protected override void OnStop()
        {
        }

        //Executes CheckSong every 10 seconds
        private void PollSong()
        {
            Timer timer = new Timer(10000); //10 seconds
            timer.Elapsed += new ElapsedEventHandler(this.CheckSong);
            timer.Start();
        }

        private void CheckSong(object sender, ElapsedEventArgs e)
        {
            //check if new song is playing
        }
    }
}
