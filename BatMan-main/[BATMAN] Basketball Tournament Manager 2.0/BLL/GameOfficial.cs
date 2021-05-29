using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.BLL
{
    public class GameOfficial
    {
        public int      gameofficialID   { get; set; }
        public string   gameofficialName { get; set; }
        public string   gameofficialDesc { get; set; }

        public bool isGameOfficialExist()
        {
            var gameOfficial = GameOfficialsHelper.GetGameOfficialList();

            foreach (var list in gameOfficial)
            {
                if(list.gameofficialName == gameofficialName)
                {
                    MessageBox.Show(gameofficialName + "is registered", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; 
                }
            }
            return true;
        }
        public bool validateofficialList(string firstName , string lastName)
        {
            bool validate = true;

            if (gameofficialName.Length == 0)
            {
                MessageBox.Show("Please provide the missing fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (firstName.Length == 0)
            {
                MessageBox.Show("Please provide the missing fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (lastName.Length == 0)
            {
                MessageBox.Show("Please provide the missing fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (gameofficialDesc.Length == 0)
            {
                MessageBox.Show("Please provide the missing fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return validate;
        }

    }
}
