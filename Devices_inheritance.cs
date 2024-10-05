internal class Device
{
    // Declare the variables
    protected int barcode;
    protected string brand;
    protected string modelNumber;

    // Create the constructor
    public Device(int barcode, string brand, string modelNumber)
    {
        this.barcode = barcode;
        this.brand = brand;
        this.modelNumber = modelNumber;
    }

    // Declaring the methods
    public int GetBarcode() { return barcode; }
    public string GetBrand() { return brand; }
    public string GetModelNum() { return modelNumber; }

    // Method to output
    public override string ToString()
    {
        string s = "Barcode: " + barcode;
        s += "\nBrand: " + brand;
        s += "\nModel Number: " + modelNumber;
        return s;
    }
}

internal class Computer:Device
{
    //Declare the protected variables
    protected string cpu;
    protected int ram;
    protected int hardDriveCapacity;

    //Constructor
    public Computer(int barcode, string brand, string modelNumber, string cpu, int ram, int hardDriveCapacity)
        :base(barcode, brand, modelNumber)
    {
        this.cpu = cpu;
        this.ram = ram;
        this.hardDriveCapacity = hardDriveCapacity;
    }

    // Methods
    public string GetCpu() { return cpu; }
    public int GetRam() { return ram; }
    public int GetHddCapacity () { return hardDriveCapacity; }

    public override string ToString()
    {
        string s = base.ToString();
        s += "\nCPU: " + cpu;
        s += "\nRAM: " + ram;
        s += "\nHard Drive Capacity: " + hardDriveCapacity;
        return s;
    }
}

internal class LaserPrinter:Printer
{
    //Variables
    protected bool colour;
    protected bool duplex;

    //Constructor
    public LaserPrinter(int barcode, string brand, string modelNumber, int maxResolutionX, int maxResolutionY, bool colour, bool duplex)
        :base(barcode, brand, modelNumber, maxResolutionX, maxResolutionY)
    {
        this.colour = colour;
        this.duplex = duplex;
    }

    //Methods
    public bool HasColour() { return colour; }
    public bool HasDuplex() { return duplex; }

    //Output
    public override string ToString()
    {
        string s = base.ToString();
        s += "\nHas Colour: " + colour;
        s += "\nHas Duplex: " + duplex;
        return s;
    }
}

internal class OfficeLaserPrinter : LaserPrinter
{
    //Variables
    private bool feeder;

    //Constructor
    public OfficeLaserPrinter(int barcode, string brand, string modelNumber, int maxResolutionX, int maxResolutionY, bool colour, bool duplex, bool feeder)
        :base(barcode, brand, modelNumber, maxResolutionX, maxResolutionY, colour, duplex)
    {
        this.feeder = feeder;
    }

    //Methods
    public bool HasFeeder() { return feeder; }

    //Output
    public override string ToString()
    {
        string s = base.ToString();
        s += "\nHas Feeder: " + feeder;
        return s;
    }
}

internal class PC:Computer
{
    //Variables
    private string assignedRoom;

    //Constructor
    public PC (int barcode, string brand, string modelNumber, string cpu, int ram, int hardDriveCapacity, string assignedRoom)
        :base(barcode, brand, modelNumber, cpu, ram, hardDriveCapacity)
    {
        this.assignedRoom = assignedRoom;
    }
    //Methods
    public string GetAssignedRoom() { return assignedRoom; }

    //Output
    public override string ToString()
    {
        string s = base.ToString();
        s += "\nAssigned Room: " + assignedRoom;
        return s;
    }
}

internal class Printer : Device
{
    //Variables
    protected int maxResolutionX;
    protected int maxResolutionY;

    //Constructor
    public Printer(int barcode, string brand, string modelNumber, int maxResolutionX, int maxResolutionY)
        :base(barcode, brand, modelNumber)
    {
        this.maxResolutionX = maxResolutionX;
        this.maxResolutionY = maxResolutionY;
    }

    //Methods
    public int GetResolutionX() { return maxResolutionX; }
    public int GetResolutionY() { return maxResolutionY; }

    //Output
    public override string ToString()
    {
        string s = base.ToString();
        s += "\nMax Resolution X: " + maxResolutionX;
        s += "\nMax Resolution Y: " + maxResolutionY;
        return s;
    }
}

internal class Tablet:Computer
{
    //Variables
    private bool stylus;

    //Constructor
    public Tablet (int barcode, string brand, string modelNumber, string cpu, int ram, int hardDriveCapacity, bool stylus)
        :base(barcode, brand, modelNumber, cpu, ram, hardDriveCapacity)
    {
        this.stylus = stylus;
    }

    //Methods
    public bool HasStylus() { return stylus; }

    //Output
    public override string ToString()
    {
        string s = base.ToString();
        s += "\nHas Stylus: " + stylus;
        return s;
    }
}

internal class StockManager
{
    //Variables
    private int numDevices;
    private int maxDevices;
    private Device[] deviceList;

    //Constructor
    public StockManager(int maxDevices)
    {
        this.maxDevices = maxDevices;
        this.numDevices = 0;
        this.deviceList = new Device[maxDevices]; // The size of the array is equal to the maxDevices.
    }

    //Methods to every kind of device:

    // PC
    public bool AddDevice(int barcode, string brand, string modelNumber, string cpu, int ram, int hardDriveCapacity, string assignedRoom)
    {
        if (numDevices < maxDevices)
        {
            deviceList[numDevices] = new PC(barcode, brand, modelNumber, cpu, ram, hardDriveCapacity, assignedRoom);
            numDevices++;
            return true;
        }
        return false;
    }

    //Tablet
    public bool AddDevice(int barcode, string brand, string modelNumber, string cpu, int ram, int hardDriveCapacity, bool stylus)
    {
        if (numDevices < maxDevices)
        {
            deviceList[numDevices] = new Tablet(barcode, brand, modelNumber, cpu, ram, hardDriveCapacity, stylus);
            numDevices++;
            return true;
        }
        return false;
    }

    //Laser Printer
    public bool AddDevice(int barcode, string brand, string modelNumber, int maxResolutionX, int maxResolutionY, bool colour, bool duplex)
    {
        if(numDevices < maxResolutionX)
        {
            deviceList[numDevices] = new LaserPrinter(barcode, brand, modelNumber, maxResolutionX, maxResolutionY, colour, duplex);
            numDevices++;
            return true;
        }
        return false;
    }

    //Office Laser Printer
    public bool AddDevice(int barcode, string brand, string modelNumber, int maxResolutionX, int maxResolutionY, bool colour, bool duplex, bool feeder)
    {
        if (numDevices < maxResolutionY)
        {
            deviceList[numDevices] = new OfficeLaserPrinter(barcode, brand, modelNumber, maxResolutionX, maxResolutionY, colour, duplex, feeder);
            numDevices++;
            return true;
        }
        return false;
    }

    //Output
    public string ListAllDevices()
    {
        string s = "----------- DEVICE LIST ----------";
        for (int i=0; i<numDevices; i++)
        {
            s += "\n" + deviceList[i].ToString() + "\n";
        }
        return s;
    }
}


internal class Program
{
    public static void Main(string[] args)
    {
        // Cratea a StockManager with a maxium of 10 devices
        StockManager stockManager = new StockManager(10);

        // Add a PC
        //(int barcode, string brand, string modelNumber, string cpu, int ram, int hardDriveCapacity, string assignedRoom)
        stockManager.AddDevice(1001, "Deel", "XOS123", "Intel core", 16, 2000, "Room 3");

        // Add a Tablet
        stockManager.AddDevice(1002, "Apple", "iPad Pro", "A12Z", 6, 256, true);

        // Add a Laser Printer
        stockManager.AddDevice(1003, "HP", "LaserJet Pro", 1200, 1200, true, true);

        // Add an Office Laser Printer
        stockManager.AddDevice(1004, "Canon", "ImageClass", 2400, 2400, true, true, true);

        // Laser Printer
        stockManager.AddDevice(1352, "HP", "480", 16, 32, true, true);

        // PC
        stockManager.AddDevice(5346, "Samsung", "340", "Intel", 16, 1000, "Room 2");

        //Output
        Console.WriteLine(stockManager.ListAllDevices());
        Console.ReadKey();
    }
}
