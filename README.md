# Drone FleetData Processing Progect

## משתתפים
```
יצחק ריינר
נתנאל פרדס
```

## classes

Drone : מייצג טיפוס רחפן

Validation : מוודא תקינות פרטי רחפן

SummeryDrones : מבצע שאילתות סטטיסטיקה

ReadDronesFile : IDroneReader : קריאת קובץ הקלט.

WriteDronesFile : IDroneWriter : כתיבת רשימת האובייקטים לקובץ גייסון

((WriteTextToFile : כתיבת טקסט (סטטיסטיקה) לקובץ טקסט))

DronesManager : מנהל תהליך המערכת

ConsoleLogger : ILogger: מדפיס למסך

PathManager : מנהל את תהליך הנתיבים במערכת

Consts : ערכים קבועים

## interfaces

 IDroneReader { public List<Drone> Read(string source); } : מתחייב לקריאת הרחפנים לרשימה

 public void Write(string path, List<Drone> drones); : מתחייב לכתיבת רשימת רחפנים לפלט הרצוי

 public interface ILogger { public void WriteLog(string message); } : מתחייב לכתיבת הודעה

 public interface IPathManager
{
    public string getInputRawPath(string name);
    public string getOutputPath(string name);
    public string getInputTestScenariosPath(string name);
} : מתחייב לניהול נתיבי מקור ומטרה

## חלוקת העבודה

### עבודה משותפת:

Program

DronesManager

SummeryDrones

### נתנאל:

Validation

PathManager

all Exceptions

### יצחק:

Drone

ReadDronesFile

WriteDronesFile

logger

consts

all interfaces

