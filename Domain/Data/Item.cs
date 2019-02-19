namespace Domain.Data
{
    public class Item
    {
        private string x;

        public Item(string rawItemData)
        {
            var data = rawItemData.Split('-');

            ItemID = data[0];
            ItemQuantity = data[1];
            ItemPrice = data[2];
        }

        public string ItemID { get; set; }
        public string ItemQuantity { get; set; }
        public string ItemPrice { get; set; }
    }
}