namespace ZarzadzanieFlota
{
    enum VehicleTypes
    {
        Bus = 0, //Auto bus
        NotABus = 1, //Tramwaj - widać, że nie autobus
        MaybeBus = 2 //Trolej bus - no jakiś bus to jest
    }

    enum ShiftTypes
    {
        Morning = 0, //Godziny 5 - 13
        Afternoon = 1, //Godziny 13 - 21
        Night = 2 //Godzniy 21 - 5
    }

    enum LineTypes
    {
        Normal = 0,
        Night = 1
    }
}
