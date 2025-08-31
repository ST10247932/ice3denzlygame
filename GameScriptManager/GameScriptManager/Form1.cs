using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameScriptManager
{
    public partial class Form1 : Form
    {
        // Your custom linked list to hold story nodes
        private readonly StoryLinkedList storyList = new StoryLinkedList();
        private List<StoryNode> sortedNodes = new List<StoryNode>();

        public Form1()
        {
            InitializeComponent();

            // Wire events here:
            btnLoadScripts.Click += BtnLoadScripts_Click;
            lstScripts.SelectedIndexChanged += LstScripts_SelectedIndexChanged;
            btnSaveScript.Click += BtnSaveScript_Click;
            btnRunScript.Click += BtnRunScript_Click;
            btnDeleteScript.Click += BtnDeleteScript_Click;
            this.Load += Form1_Load;               // Form load event wired here
            lblScriptName.Click += lblScriptName_Click; // Label click event wired here

            // Initialize label and richtextbox states
            lblScriptName.Text = "Select a script line...";
            rtbScriptContent.ReadOnly = false; // Allow editing for Save to make sense
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            ShowFullStory();
        }

        private void lblScriptName_Click(object sender, EventArgs e)
        {
            // Optional - leave empty or add functionality
        }

        private void LoadData()
        {
            storyList.Clear();

            storyList.AddNode(3, "With every line of code mastered, Alex gains experience points, leveling up and unlocking new abilities like Debugging Dash and Algorithmic Aura.");
            storyList.AddNode(12, "The tale of Alex, the IT student-turned-digital-legend, is forever etched in the annals of Cybersphere, inspiring aspiring programmers to pursue their dreams.");
            storyList.AddNode(4, "The Firewall Fortress looms ahead, its defenses formidable, but Alex's mastery of cybersecurity allows them to breach the walls with a series of perfectly timed hacks.");
            storyList.AddNode(2, "Armed with a trusty keyboard and a digital sword, Alex enters the Coding Caverns, where bugs and glitches guard the treasures of programming wisdom.");
            storyList.AddNode(1, "In the virtual realm of Cybersphere, our hero, Alex, a determined IT student, embarks on an epic quest for knowledge.");
            storyList.AddNode(7, "Along the journey, Alex forges alliances with NPC coders, forming a guild known as 'Syntax Sentinels,' united by their dedication to digital mastery.");
            storyList.AddNode(10, "Victory is hard-won, but Alex's leadership and IT prowess lead to the defeat of the Malware Marauders, restoring peace to Cybersphere.");
            storyList.AddNode(11, "Celebrated as a digital hero, Alex stands at the forefront of innovation, using the knowledge gained to create groundbreaking applications that shape the future of technology.");
            storyList.AddNode(9, "In a climactic battle, Alex and the Syntax Sentinels engage in a virtual war, using complex algorithms and strategic thinking to outwit the Malware Marauders' schemes.");
            storyList.AddNode(5, "Inside the fortress, a virtual reality riddle awaits – a puzzle that can only be solved by applying principles of encryption and decryption learned during countless late-night study sessions.");
            storyList.AddNode(6, "Emerging victorious, Alex discovers the hidden Repository of the Ancients, a collection of long-lost IT texts rumored to contain the ultimate programming language.");
            storyList.AddNode(8, "The guild faces its nemesis in the form of the Malware Marauders, a rival group aiming to spread chaos and disrupt the digital realm.");

            storyList.Sort();

            sortedNodes = storyList.ToList();
        }

        private void ShowFullStory()
        {
            rtbScriptContent.Text = string.Join(Environment.NewLine + Environment.NewLine, sortedNodes.ConvertAll(n => n.StoryText));
            lblScriptName.Text = "Full Story";
            lstScripts.ClearSelected();
        }

        private void BtnLoadScripts_Click(object sender, EventArgs e)
        {
            LoadData();

            lstScripts.Items.Clear();
            foreach (var node in sortedNodes)
            {
                string preview = node.StoryText.Length > 30 ? node.StoryText.Substring(0, 30) + "..." : node.StoryText;
                lstScripts.Items.Add($"#{node.StoryNumber}: {preview}");
            }

            if (lstScripts.Items.Count > 0)
            {
                lstScripts.SelectedIndex = 0;
            }
        }

        private void LstScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = lstScripts.SelectedIndex;
            if (idx >= 0 && idx < sortedNodes.Count)
            {
                var node = sortedNodes[idx];
                lblScriptName.Text = $"Story #{node.StoryNumber}";
                rtbScriptContent.Text = node.StoryText;
            }
            else
            {
                lblScriptName.Text = "Select a script line...";
                rtbScriptContent.Clear();
            }
        }

        // Save edits made to the selected script
        private void BtnSaveScript_Click(object sender, EventArgs e)
        {
            int idx = lstScripts.SelectedIndex;
            if (idx >= 0 && idx < sortedNodes.Count)
            {
                sortedNodes[idx].StoryText = rtbScriptContent.Text;

                // Update linked list nodes accordingly (rebuild list from sortedNodes)
                RebuildLinkedListFromList();

                MessageBox.Show("Script saved successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh ListBox preview text
                lstScripts.Items[idx] = $"#{sortedNodes[idx].StoryNumber}: " +
                    (sortedNodes[idx].StoryText.Length > 30 ? sortedNodes[idx].StoryText.Substring(0, 30) + "..." : sortedNodes[idx].StoryText);
            }
            else
            {
                MessageBox.Show("Please select a script to save.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // "Run" script simulation - just show message box with script content
        private void BtnRunScript_Click(object sender, EventArgs e)
        {
            int idx = lstScripts.SelectedIndex;
            if (idx >= 0 && idx < sortedNodes.Count)
            {
                var scriptText = sortedNodes[idx].StoryText;
                MessageBox.Show($"Running script:\n\n{scriptText}", "Run Script", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a script to run.", "Run Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Delete selected script from list and linked list
        private void BtnDeleteScript_Click(object sender, EventArgs e)
        {
            int idx = lstScripts.SelectedIndex;
            if (idx >= 0 && idx < sortedNodes.Count)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this script?", "Delete Script", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    sortedNodes.RemoveAt(idx);

                    // Rebuild linked list from the updated list
                    RebuildLinkedListFromList();

                    // Refresh ListBox items
                    lstScripts.Items.RemoveAt(idx);

                    if (lstScripts.Items.Count > 0)
                    {
                        lstScripts.SelectedIndex = Math.Min(idx, lstScripts.Items.Count - 1);
                    }
                    else
                    {
                        lblScriptName.Text = "Select a script line...";
                        rtbScriptContent.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a script to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Helper: rebuild linked list from sortedNodes list after edit/delete
        private void RebuildLinkedListFromList()
        {
            storyList.Clear();
            foreach (var node in sortedNodes)
            {
                storyList.AddNode(node.StoryNumber, node.StoryText);
            }
            storyList.Sort(); // Keep it sorted
            sortedNodes = storyList.ToList();
        }
    }

    // Node class for storing story data
    public class StoryNode
    {
        public int StoryNumber { get; set; }
        public string StoryText { get; set; }
        public StoryNode Next { get; set; }

        public StoryNode(int number, string text)
        {
            StoryNumber = number;
            StoryText = text;
            Next = null;
        }
    }

    // Custom singly linked list for story nodes
    public class StoryLinkedList
    {
        private StoryNode head;

        public StoryLinkedList()
        {
            head = null;
        }

        // Add node at the end
        public void AddNode(int storyNumber, string storyText)
        {
            StoryNode newNode = new StoryNode(storyNumber, storyText);

            if (head == null)
            {
                head = newNode;
                return;
            }

            StoryNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        // Clear the list
        public void Clear()
        {
            head = null;
        }

        // Sort linked list using Bubble Sort by StoryNumber
        public void Sort()
        {
            if (head == null || head.Next == null)
                return;

            bool swapped;
            do
            {
                swapped = false;
                StoryNode current = head;
                StoryNode prev = null;

                while (current.Next != null)
                {
                    if (current.StoryNumber > current.Next.StoryNumber)
                    {
                        // Swap nodes by adjusting links
                        StoryNode tmp = current.Next;
                        current.Next = tmp.Next;
                        tmp.Next = current;

                        if (prev == null)
                            head = tmp;
                        else
                            prev.Next = tmp;

                        prev = tmp;
                        swapped = true;
                    }
                    else
                    {
                        prev = current;
                        current = current.Next;
                    }
                }
            } while (swapped);
        }

        // Convert linked list to List<StoryNode>
        public List<StoryNode> ToList()
        {
            List<StoryNode> list = new List<StoryNode>();
            StoryNode current = head;
            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }
    }
}
