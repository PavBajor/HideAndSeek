using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp15
{
    public partial class HideAndSeek : Form
    {
        int moves;
        RoomWithDoor kitchen;
        RoomWithDoor livingRoom;
        Room diningRoom;
        Room stairs;
        RoomWithHidingPlace masterBedroom;
        RoomWithHidingPlace secondBedroom;
        RoomWithHidingPlace bathRoom;
        RoomWithHidingPlace upstairHallway;

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        OutsideWithHidingPlace garden;
        OutsideWithHidingPlace driveway;
        Location currentLocation;
        Opponent opponent;

        void CreateObjects()
        {
            kitchen = new RoomWithDoor("an antique carpet", "kitchen", "behind the door", "screen door");
            livingRoom = new RoomWithDoor("stainless steel appliances", "living room", "behind the door", "oak door with brass knob");
            diningRoom = new Room("crystal chandelier", "dining Room");
            stairs = new Room("wooden banister", "stairs");
            masterBedroom = new RoomWithHidingPlace("large bed", "master bedroom", "under the bed");
            secondBedroom = new RoomWithHidingPlace("small bed", "second bedroom", "under the bed");
            bathRoom = new RoomWithHidingPlace("toilet and sink", "bathroom", "in the shower");
            upstairHallway = new RoomWithHidingPlace("picture of a dog", "upstair hallway", "inside the closet");


            frontYard = new OutsideWithDoor(false, "front yard", "behind the door", "oak door with brass knob");
            backYard = new OutsideWithDoor(true, "back Yard", "behind the door", "screen door");
            garden = new OutsideWithHidingPlace(false, "garden", "in the shed");
            driveway = new OutsideWithHidingPlace(true, "driveway", "in the garage");

            
            frontYard.Exits = new Location[] { livingRoom, garden, driveway };
            backYard.Exits = new Location[] { kitchen, garden, driveway };
            driveway.Exits = new Location[] { frontYard, backYard };
            garden.Exits = new Location[] { frontYard, backYard };
            kitchen.Exits = new Location[] { diningRoom, backYard };
            diningRoom.Exits = new Location[] { kitchen, livingRoom };
            livingRoom.Exits = new Location[] { diningRoom, frontYard };
            stairs.Exits = new Location[] { livingRoom, upstairHallway };
            upstairHallway.Exits = new Location[] { masterBedroom, secondBedroom, bathRoom };
            masterBedroom.Exits = new Location[] { upstairHallway };
            secondBedroom.Exits = new Location[] { upstairHallway };
            bathRoom.Exits = new Location[] { upstairHallway };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;

            currentLocation = frontYard;

        }

        
        

        void MoveToANewLocation(Location destination)
        {
            moves++;
            currentLocation = destination;
            

           
            RedrawForm();
        }

        void RedrawForm()
        {
            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exits.Items.Add(currentLocation.Exits[i].Name);
            }
            exits.SelectedIndex = 0;
            SetDescription();
            
            if (currentLocation is IHidingPlace)
            {
                IHidingPlace hidingPlace = currentLocation as IHidingPlace;
                check.Text = "Check " + hidingPlace.HidingPlaceName;
                check.Visible = true;
            }
            else
            {
                check.Visible = false;
                if (currentLocation is IHasExteriorDoor)
                {
                    goThroughTheDoor.Visible = true;
                }
                else
                {
                    goThroughTheDoor.Visible = false;
                }
            }
        }

        void SetDescription()
        {
            description.Text = currentLocation.Description + "\n move #" + moves; ;
        }
        void ResetGame(bool displayMessage)
        {
            if (displayMessage)
            {
                MessageBox.Show("You found your opponent in " + moves + " moves!");
                IHidingPlace foundLocation = currentLocation as IHidingPlace;
                description.Text = "You found your opponent in " + moves + " moves! He wa hiding " + foundLocation.HidingPlaceName + "."; 
            }
            moves = 0;
            goHere.Visible = false;
            goThroughTheDoor.Visible = false;
            check.Visible = false;
            exits.Visible = false;
        }
        public HideAndSeek()
        {
            
            InitializeComponent();
            CreateObjects();
            opponent = new Opponent(frontYard);
            ResetGame(false);
            MoveToANewLocation(livingRoom);
            
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void exits_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void hide_Click(object sender, EventArgs e)
        {
            hide.Visible = false;
            for (int i = 1; i <= 10; i++)
            {
                   
                opponent.Move();
                description.Text = i + "...";
                Application.DoEvents();
                Thread.Sleep(500);
            }
            description.Text = "Ready or not here i come!";
            Application.DoEvents();
            Thread.Sleep(1000);

            goHere.Visible = true;
            exits.Visible = true;
            MoveToANewLocation(livingRoom);
            
        }

        private void check_Click(object sender, EventArgs e)
        {
            moves++;
            if (opponent.Check(currentLocation))
            {
                ResetGame(true);
            }
            else
            {
                description.Text = "Not here!";
                RedrawForm();
            }
        }
    }
}
