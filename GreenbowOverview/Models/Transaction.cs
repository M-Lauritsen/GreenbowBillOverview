public class Transaction
{
    public string id { get; set; }
    public int transaction_id { get; set; }
    public DateTime started_at { get; set; }
    public DateTime ended_at { get; set; }
    public int charged_wh { get; set; }
    public string started_by_id_tag { get; set; }
    public string started_by_extra { get; set; }
    public object stopped_by_id_tag { get; set; }
    public object reservation_id { get; set; }
    public string amount_base { get; set; }
    public string amount_vat { get; set; }
    public string amount_total { get; set; }
    public string amount_currency { get; set; }
    public string amount_status { get; set; }
    public string amount_status_text { get; set; }
    public string charger_nickname { get; set; }
    public bool is_vehicle_updatable { get; set; }
    public Vehicle vehicle { get; set; }
    public string tax_account_amount_total { get; set; }
    public string tariff_amount_total { get; set; }
    public string spot_price_amount_total { get; set; }
    public string amount_ex_tax_account_amount_total { get; set; }

    public class Vehicle
    {
        public string id { get; set; }
        public string owner_user_id { get; set; }
        public bool is_owner { get; set; }
        public bool is_updatable { get; set; }
        public string name { get; set; }
        public string reg_no { get; set; }
        public string id_tag { get; set; }
        public object brand { get; set; }
        public object model { get; set; }
        public object year { get; set; }
        public object capacity_wh { get; set; }
        public object phases { get; set; }
        public int ac_power_w { get; set; }
        public object dc_power_w { get; set; }
        public bool is_deleted { get; set; }
        public bool is_deletable { get; set; }
    }

    public Vehicle VehicleDetails { get; set; }
    // Add other properties as needed
}
