/**
 * Quan Nguyen
 * CST-150
 * Milestone
 * 4/3/2022
 * This is my own work (with some ideas from StackOverflow)
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace CST150Milestone
{
    public partial class CoffeeInventory : Form
    {
        // Declare and instantiate two objects for music players
        WindowsMediaPlayer player1 = new WindowsMediaPlayer();
        WindowsMediaPlayer player2 = new WindowsMediaPlayer();

        // Declare, instantiate, and initialize an array from Coffee class 
        Coffee[] coffeeInvArr = new Coffee[6];
        public CoffeeInventory()
        {
            InitializeComponent();
            // Get the music file from the Debug folder
            player1.URL = "loading.mp3";
            player2.URL = "shop.mp3";

            // Dock the Loading label to the first picture
            lblLoading.Parent = pictureBox1;

            // Dock the label and buttons to the second picture
            lblWelcome.Parent = pictureBox2;
            btnStart.Parent = pictureBox2;
            btnRemove.Parent = pictureBox2;

            // Play the first music and hold the second music
            player1.controls.play();
            player2.controls.stop();
        }

        /// <summary>
        /// Timer Tick Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Announce the timer to be stopped
            timer1.Stop();

            // Dispose the first picture and the loading label
            pictureBox1.Dispose();
            lblLoading.Dispose();

            // Stop the first music and begin the second music
            player1.controls.stop();
            player2.controls.play();
        }

        /// <summary>
        /// Button Start Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClick_EventHandler(object sender, EventArgs e)
        {
            // Hide the following tools and show the second items
            lblWelcome.Hide();
            btnStart.Hide();
            gvData.Show();
            btnRemove.Show();
            btnAdd.Show();
            btnRestock.Show();
            btnSearch.Show();
            txtSearch.Show();

            // Initialize the set of coffees in the array 
            coffeeInvArr[0] = new Coffee(false, "Espresso", "Espresso", "None", "None", 2.50, 20);
            coffeeInvArr[1] = new Coffee(false, "Macchiato", "Milk Foam", "None", "None", 3.00, 10);
            coffeeInvArr[2] = new Coffee(false, "Latte", "Espresso", "Steamed Milk", "Milk Foam", 7.55, 5);
            coffeeInvArr[3] = new Coffee(false, "Flat White", "Espresso", "Steamed Milk", "None", 3.55, 30);
            coffeeInvArr[4] = new Coffee(false, "Cappucino", "Espresso", "Steamed Milk", "Milk Foam", 4.50, 25);
            coffeeInvArr[5] = new Coffee(false, "Mocha", "Espresso", "Hot Chocolate", "Steamed Milk", 5.55, 10);
            
            // Data binding
            gvData.DataSource = coffeeInvArr;

            // Set the column of index 5 (price) to be formatted in a dollar sign
            gvData.Columns[5].DefaultCellStyle.Format = "c";
        }

        /// <summary>
        /// Button Remove Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveClick_EventHandler(object sender, EventArgs e)
        {
            foreach (DataGridViewRow gvrow in gvData.Rows)
            {
                // Read checkbox cell and put value in chkchecking (true or false)
                DataGridViewCheckBoxCell chkchecking = gvrow.Cells[0] as DataGridViewCheckBoxCell;
                if ((bool)chkchecking.Value == true)
                {
                    // Reduce the inventory
                    // Get the qty value which is element 8 of index 7
                    int qty = coffeeInvArr[gvrow.Index].Quantity;
                    // Reduce the qty by 1
                    qty--;
                    // Store the new qty back in the array
                    coffeeInvArr[gvrow.Index].Quantity = qty;
                    // Update the DataGrid View
                    gvData.Update();
                    // Refresh what is displayed in the DataGridView
                    gvData.Refresh();
                }
            }
        }

        /// <summary>
        /// Button Add Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClick_EventHandler(object sender, EventArgs e)
        {
            foreach (DataGridViewRow gvrow in gvData.Rows)
            {
                // Read checkbox cell and put value in chkchecking (true or false)
                DataGridViewCheckBoxCell chkchecking = gvrow.Cells[0] as DataGridViewCheckBoxCell;
                if ((bool)chkchecking.Value == true)
                {
                    // Reduce the inventory
                    // Get the qty value which is element 8 of index 7
                    int qty = coffeeInvArr[gvrow.Index].Quantity;
                    // Add the qty by 1
                    qty++;
                    // Store the new qty back in the array
                    coffeeInvArr[gvrow.Index].Quantity = qty;
                    // Update the DataGrid View
                    gvData.Update();
                    // Refresh what is displayed in the DataGridView
                    gvData.Refresh();
                }
            }
        }

        /// <summary>
        /// Button Restock Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRestockClick_EventHandler(object sender, EventArgs e)
        {
            // Restock the items again
            coffeeInvArr[0] = new Coffee(false, "Espresso", "Espresso", "None", "None", 2.50, 20);
            coffeeInvArr[1] = new Coffee(false, "Macchiato", "Milk Foam", "None", "None", 3.00, 10);
            coffeeInvArr[2] = new Coffee(false, "Latte", "Espresso", "Steamed Milk", "Milk Foam", 7.55, 5);
            coffeeInvArr[3] = new Coffee(false, "Flat White", "Espresso", "Steamed Milk", "None", 3.55, 30);
            coffeeInvArr[4] = new Coffee(false, "Cappucino", "Espresso", "Steamed Milk", "Milk Foam", 4.50, 25);
            coffeeInvArr[5] = new Coffee(false, "Mocha", "Espresso", "Hot Chocolate", "Steamed Milk", 5.55, 10);
            gvData.DataSource = coffeeInvArr;
            // Update the DataGrid View
            gvData.Update();
            // Refresh what is displayed in the DataGridView
            gvData.Refresh();
        }

        /// <summary>
        /// Button Search Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchClick_EventHandler(object sender, EventArgs e)
        {
            // Declare the value that is passed to the textbox
            string searchValue = txtSearch.Text;

            // Enable the selection mode for the gridview 
            gvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // try catch block to see if the data entered is valid
            try
            {
                bool valueResult = false;
                foreach (DataGridViewRow row in gvData.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().Equals(searchValue))
                        {
                            int rowIndex = row.Index;
                            gvData.Rows[rowIndex].Selected = true;
                            valueResult = true;
                            break;
                        }
                    }
                }
                if (!valueResult)
                {
                    MessageBox.Show("Sorry, the result of " + txtSearch.Text, "is not found.");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
