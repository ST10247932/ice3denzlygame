namespace GameScriptManager
{
    public class Node
    {
        public int StoryNumber { get; set; }
        public string StoryText { get; set; }
        public Node Next { get; set; }

        public Node(int number, string text)
        {
            StoryNumber = number;
            StoryText = text;
            Next = null;
        }

        public override string ToString()
        {
            return $"{StoryNumber}. {StoryText}";
        }
    }
}
