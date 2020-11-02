# About Aqua DateTime Helpers:

Aqua DateTime Helpers is an Open Source and Free Software package consists of a set of utilities that facilitate the job of the developer and save his time while dealing with a string. Every developer could be a beneficiary of this library; however, those who deal with database and integration applications are likely the most potential beneficiaries.


# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# List of Features and Methods
1. [IsValidDate](#IsValidDate)
2. [IsValidTime](#IsValidTime)
3. [IsValidDateTime](#IsValidDateTime)
4. [IsBetween](#IsBetween)
5. [IgnoreTimeSpan](#IgnoreTimeSpan)
6. [IgnoreMilliseconds](#IgnoreMilliseconds)
7. [IgnoreSeconds](#IgnoreSeconds)
8. [IgnoreMinutes](#IgnoreMinutes)
9. [IgnoreHours](#IgnoreHours)
10. [GetMinDate](#GetMinDate)
11. [GetMaxDate](#GetMaxDate)
12. [UnixTimeStampToDateTime](#UnixTimeStampToDateTime)
13. [UnixTimeStampToDateTimeUTC](#UnixTimeStampToDateTimeUTC)
14. [DateTimeToUnixTimeStamp](#DateTimeToUnixTimeStamp)
15. [IsSunday](#IsSunday)
16. [IsMonday](#IsMonday)
17. [IsTuesday](#IsTuesday)
18. [IsWednesday](#IsWednesday)
19. [IsThursday](#IsThursday)
20. [IsFriday](#IsFriday)
21. [IsSaturday](#IsSaturday)
22. [IsDateAM](#IsDateAM)
23. [IsDatePM](#IsDatePM)
24. [GenerateDateList](#GenerateDateList)
25. [GenerateBusinessDaysList](#GenerateBusinessDaysList)
26. [GetLastWeekdayOfMonth](#GetLastWeekdayOfMonth)
27. [GetFirstWeekdayOfMonth](#GetFirstWeekdayOfMonth)
28. [GetFirstDayOfWeek](#GetFirstDayOfWeek)
29. [GetLastDayOfWeek](#GetLastDayOfWeek)
30. [GetLastDayOfPreviousWeek](#GetLastDayOfPreviousWeek)
31. [GetFirstDayOfNextWeek](#GetFirstDayOfNextWeek)
32. [NextWeekSameDay](#NextWeekSameDay)
33. [PreviousWeekSameDay](#PreviousWeekSameDay)
34. [NextMonthSameDay](#NextMonthSameDay)
35. [PreviousMonthSameDay](#PreviousMonthSameDay)
36. [QuarterOfYear](#QuarterOfYear)
37. [WeekOfYear](#WeekOfYear)
38. [Midnight](#Midnight)
39. [Noon](#Noon)
40. [NextYearSameDay](#NextYearSameDay)
41. [PreviousYearSameDay](#PreviousYearSameDay)
42. [AgeCalenderYears](#AgeCalenderYears)
43. [AgeMonths](#AgeMonths)
44. [AgeExactYears](#AgeExactYears)
45. [SetTime](#SetTime)
46. [SetDay](#SetDay)
47. [SetMonth](#SetMonth)
48. [SetYear](#SetYear)

# Features and Methods

### IsValidDate
```C#
//using Aqua.DateTimeHelpers;

int year;
int month;
int day;
bool output;

year = 2019;
month = 10;
day = 15;
output = DateTimeHelpers.IsValidDate(year, month, day); // output = true

year = 2019;
month = 15;
day = 15;
output = DateTimeHelpers.IsValidDate(year, month, day); // output = false

year = 2019;
month = 10;
day = 35;
output = DateTimeHelpers.IsValidDate(year, month, day); // output = false

```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsValidTime
```C#
//using Aqua.DateTimeHelpers;

int hour;
int minute;
int second;
bool output;

hour = 10;
minute = 35;
second = 59;
output = DateTimeHelpers.IsValidTime(hour, minute, second); // output = true

hour = 35;
minute = 35;
second = 59;
output = DateTimeHelpers.IsValidTime(hour, minute, second); // output = false

hour = 10;
minute = 35;
second = 59;
output = DateTimeHelpers.IsValidTime(hour, minute, second); // output = false

```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsValidDateTime
```C#
//using Aqua.DateTimeHelpers;

int year;
int month;
int day;
int hour;
int minute;
int second;
bool output;

year = 2019;
month = 10;
day = 15;
hour = 10;
minute = 35;
second = 59;
output = DateTimeHelpers.IsValidDateTime(year, month, day, hour, minute, second); // output = true

year = 2019;
month = 15;
day = 15;
hour = 35;
minute = 35;
second = 59;
output = DateTimeHelpers.IsValidDateTime(year, month, day, hour, minute, second); // output = false

year = 2019;
month = 10;
day = 35;
hour = 10;
minute = 35;
second = 59;
output = DateTimeHelpers.IsValidDateTime(year, month, day, hour, minute, second); // output = false

```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsBetween
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime rangeStart;
DateTime rangeEnd;
bool output;

input = new DateTime(2019, 9, 9);
rangeStart = new DateTime(2018, 9, 9);
rangeEnd = new DateTime(2019, 9, 10);
output = input.IsBetween(rangeStart, rangeEnd); // output = true

input = new DateTime(2019, 9, 9, 10, 10, 57);
rangeStart = new DateTime(2019, 9, 9, 10, 10, 55);
rangeEnd = new DateTime(2019, 9, 9, 10, 10, 56);
output = input.IsBetween(rangeStart, rangeEnd); // output = false

input = new DateTime(2019, 9, 9, 10, 10, 57);
rangeStart = new DateTime(2019, 9, 9, 10, 10, 56);
rangeEnd = new DateTime(2019, 9, 10, 10, 10, 58);
output = input.IsBetween(rangeStart, rangeEnd); // output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IgnoreTimeSpan
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
TimeSpan toBeIgnored;
DateTime output;

input = new DateTime(2019, 9, 9, 10, 10, 10, 765);
toBeIgnored = TimeSpan.FromMilliseconds(1000);
output = input.IgnoreTimeSpan(toBeIgnored); // output = "09/09/2019 10:10:10"

input = new DateTime(2019, 9, 9, 10, 10, 10, 999);
toBeIgnored = TimeSpan.FromSeconds(55);
output = input.IgnoreTimeSpan(toBeIgnored); // output = "09/09/2019 10:09:45"

input = new DateTime(2019, 9, 9, 10, 10, 10, 222);
toBeIgnored = TimeSpan.FromMinutes(60);
output = input.IgnoreTimeSpan(toBeIgnored); // output = "09/09/2019 10:00:00"

```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IgnoreMilliseconds
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 9, 9, 10, 10, 10, 765);
output = input.IgnoreMilliseconds(); // output = "09/09/2019 10:10:10"

input = new DateTime(2019, 9, 9, 10, 10, 10, 999);
output = input.IgnoreMilliseconds(); // output = "09/09/2019 10:10:10"

input = new DateTime(2019, 9, 9, 10, 10, 10, 222);
output = input.IgnoreMilliseconds(); // output = "09/09/2019 10:10:10"

```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IgnoreSeconds
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 9, 9, 10, 10, 10, 765);
output = input.IgnoreSeconds(); // output = "09/09/2019 10:10:00"

input = new DateTime(2019, 9, 9, 10, 10, 15, 999);
output = input.IgnoreSeconds(); // output = "09/09/2019 10:10:00"

input = new DateTime(2019, 9, 9, 10, 10, 55, 222);
output = input.IgnoreSeconds(); // output = "09/09/2019 10:10:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IgnoreMinutes
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 9, 9, 10, 10, 10, 765);
output = input.IgnoreMinutes(); // output = "09/09/2019 10:00:00"

input = new DateTime(2019, 9, 9, 10, 55, 10, 999);
output = input.IgnoreMinutes(); // output = "09/09/2019 10:00:00"

input = new DateTime(2019, 9, 9, 10, 44, 10, 222);
output = input.IgnoreMinutes(); // output = "09/09/2019 10:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IgnoreHours
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 9, 9, 10, 10, 10, 765);
output = input.IgnoreHours(); // output = "09/09/2019 00:00:00"

input = new DateTime(2019, 9, 9, 17, 55, 10, 999);
output = input.IgnoreHours(); // output = "09/09/2019 00:00:00"

input = new DateTime(2019, 9, 9, 23, 44, 10, 222);
output = input.IgnoreHours(); // output = "09/09/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### GetMinDate
```C#
//using Aqua.DateTimeHelpers;

DateTime output;

output = DateTimeHelpers.GetMinDate(); //output = "01/01/0001 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### GetMaxDate
```C#
//using Aqua.DateTimeHelpers;

DateTime output;

output = DateTimeHelpers.GetMaxDate(); //output = "31/12/9999 23:59:59"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### UnixTimeStampToDateTime
```C#
//using Aqua.DateTimeHelpers;

DateTime output;

output = DateTimeHelpers.UnixTimeStampToDateTime(78787878); //output = "30/06/1972 22:31:18"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### UnixTimeStampToDateTimeUTC
```C#
//using Aqua.DateTimeHelpers;

DateTime output;

output = DateTimeHelpers.UnixTimeStampToDateTimeUTC(787878788); //output = "19/12/1994 23:13:08"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### DateTimeToUnixTimeStamp
```C#
//using Aqua.DateTimeHelpers;

DateTime input = new DateTime(1994, 12, 19, 23, 13, 08);

double output;

output = DateTimeHelpers.DateTimeToUnixTimeStamp(input); //output = 787878788
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsSunday
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
bool output;

input = new DateTime(1994, 12, 19, 23, 13, 08);

output = input.IsSunday(); //output = false

input = new DateTime(2019, 7, 14, 23, 13, 08);

output = input.IsSunday(); //output = true

input = new DateTime(2019, 7, 21);

output = input.IsSunday(); //output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsMonday
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
bool output;

input = new DateTime(1994, 12, 18, 22, 13, 08);

output = input.IsMonday(); //output = false

input = new DateTime(2019, 7, 15, 20, 13, 08);

output = input.IsMonday(); //output = true

input = new DateTime(2019, 7, 22);

output = input.IsMonday(); //output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsTuesday
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
bool output;

input = new DateTime(1994, 12, 19, 22, 13, 08);

output = input.IsTuesday(); //output = false

input = new DateTime(2019, 7, 16, 20, 13, 08);

output = input.IsTuesday(); //output = true

input = new DateTime(2019, 7, 23);

output = input.IsTuesday(); //output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsWednesday
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
bool output;

input = new DateTime(1994, 12, 20, 22, 13, 08);

output = input.IsWednesday(); //output = false

input = new DateTime(2019, 7, 17, 20, 13, 08);

output = input.IsWednesday(); //output = true

input = new DateTime(2019, 7, 24);

output = input.IsWednesday(); //output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsThursday
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
bool output;

input = new DateTime(1994, 12, 21, 22, 13, 08);

output = input.IsThursday(); //output = false

input = new DateTime(2019, 7, 18, 20, 13, 08);

output = input.IsThursday(); //output = true

input = new DateTime(2019, 7, 25);

output = input.IsThursday(); //output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsFriday
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
bool output;

input = new DateTime(1994, 12, 22, 22, 13, 08);

output = input.IsFriday(); //output = false

input = new DateTime(2019, 7, 19, 20, 13, 08);

output = input.IsFriday(); //output = true

input = new DateTime(2019, 7, 26);

output = input.IsFriday(); //output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsSaturday
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
bool output;

input = new DateTime(1994, 12, 23, 22, 13, 08);

output = input.IsSaturday(); //output = false

input = new DateTime(2019, 7, 20, 20, 13, 08);

output = input.IsSaturday(); //output = true

input = new DateTime(2019, 7, 27);

output = input.IsSaturday(); //output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsDateAM
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
bool output;

input = new DateTime(1994, 12, 23, 22, 13, 08);

output = input.IsDateAM(); //output = false

input = new DateTime(2019, 7, 20, 03, 13, 08);

output = input.IsDateAM(); //output = true

input = new DateTime(2019, 7, 27);

output = input.IsDateAM(); //output = true
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### IsDatePM
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
bool output;

input = new DateTime(1994, 12, 23, 22, 13, 08);

output = input.IsDatePM(); //output = true

input = new DateTime(2019, 7, 20, 03, 13, 08);

output = input.IsDatePM(); //output = false

input = new DateTime(2019, 7, 27);

output = input.IsDatePM(); //output = false
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### GenerateDateList
```C#
//using Aqua.DateTimeHelpers;

DateTime startDate;
DateTime endDate;
List<DateTime> output = new List<DateTime>();

startDate = new DateTime(1994, 12, 23);
endDate = new DateTime(1994, 12, 29);

output = DateTimeHelpers.GenerateDateList(startDate, endDate);
//output = {"23/12/1994 00:00:00", "24/12/1994 00:00:00", "25/12/1994 00:00:00", "26/12/1994 00:00:00", 
//          "27/12/1994 00:00:00", "28/12/1994 00:00:00", "29/12/1994 00:00:00", }

```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### GenerateBusinessDaysList
```C#
//using Aqua.DateTimeHelpers;

DateTime startDate;
DateTime endDate;
List<DateTime> holydays = new List<DateTime> {
        new DateTime(2019, 1,  1 ),
        new DateTime(2019, 4,  19),
        new DateTime(2019, 4,  22),
        new DateTime(2019, 5,  6 ),
        new DateTime(2019, 5,  27),
        new DateTime(2019, 8,  26),
        new DateTime(2019, 12, 25),
        new DateTime(2019, 12, 26)
        };

List<int> weekendDays = new List<int> { 6, 0 };

IEnumerable<DateTime> output = new List<DateTime>();

startDate = new DateTime(2019, 1, 1);
endDate = new DateTime(2019, 1, 9);

output = DateTimeHelpers.GenerateBusinessDaysList(startDate, endDate, holydays, weekendDays);
//output = {"02/01/2019 00:00:00", "03/01/2019 00:00:00", "04/01/2019 00:00:00", 
//          "07/01/2019 00:00:00", "08/01/2019 00:00:00", "09/01/2019 00:00:00"}

```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### GetLastWeekdayOfMonth
```C#
//using Aqua.DateTimeHelpers;

int year;
int month;
DayOfWeek dayOfWeek;

DateTime output;

year = 2019;
month = 8;
dayOfWeek = DayOfWeek.Sunday;
output = DateTimeHelpers.GetLastWeekdayOfMonth(year, month, dayOfWeek); // "25/08/2019 00:00:00"

year = 2019;
month = 8;
dayOfWeek = DayOfWeek.Friday;
output = DateTimeHelpers.GetLastWeekdayOfMonth(year, month, dayOfWeek); // "30/08/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### GetFirstWeekdayOfMonth
```C#
//using Aqua.DateTimeHelpers;

int year;
int month;
DayOfWeek dayOfWeek;

DateTime output;

year = 2019;
month = 8;
dayOfWeek = DayOfWeek.Sunday;
output = DateTimeHelpers.GetFirstWeekdayOfMonth(year, month, dayOfWeek); // "04/08/2019 00:00:00"

year = 2019;
month = 8;
dayOfWeek = DayOfWeek.Friday;
output = DateTimeHelpers.GetFirstWeekdayOfMonth(year, month, dayOfWeek); // "02/08/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### GetFirstDayOfWeek
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5);

output = DateTimeHelpers.GetFirstDayOfWeek(input); // "29/04/2019 00:00:00"

input = new DateTime(2019, 5, 15);

output = DateTimeHelpers.GetFirstDayOfWeek(input); // "13/05/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### GetLastDayOfWeek
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5);

output = DateTimeHelpers.GetLastDayOfWeek(input); // "05/05/2019 00:00:00"

input = new DateTime(2019, 5, 15);

output = DateTimeHelpers.GetLastDayOfWeek(input); // "19/05/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### GetLastDayOfPreviousWeek
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5);

output = DateTimeHelpers.GetLastDayOfPreviousWeek(input); // "28/04/2019 00:00:00"

input = new DateTime(2019, 5, 15);

output = DateTimeHelpers.GetLastDayOfPreviousWeek(input); // "12/05/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### GetFirstDayOfNextWeek
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5);

output = DateTimeHelpers.GetFirstDayOfNextWeek(input); // "06/05/2019 00:00:00"

input = new DateTime(2019, 5, 15);

output = DateTimeHelpers.GetFirstDayOfNextWeek(input); // "20/05/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### NextWeekSameDay
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5);

output = input.NextWeekSameDay(); // "12/05/2019 00:00:00"

input = new DateTime(2019, 5, 15);

output = input.NextWeekSameDay(); // "22/05/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### PreviousWeekSameDay
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5);

output = input.PreviousWeekSameDay(); // "28/04/2019 00:00:00"

input = new DateTime(2019, 5, 15);

output = input.PreviousWeekSameDay(); // "08/05/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### NextMonthSameDay
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5);

output = input.NextMonthSameDay(); // "05/06/2019 00:00:00"

input = new DateTime(2019, 5, 15);

output = input.NextMonthSameDay(); // "15/06/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### PreviousMonthSameDay
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5);

output = input.PreviousMonthSameDay(); // "05/04/2019 00:00:00"

input = new DateTime(2019, 5, 15);

output = input.PreviousMonthSameDay(); // "15/04/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### QuarterOfYear
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
int output;

input = new DateTime(2019, 5, 5);

output = input.QuarterOfYear(); // output = 2

input = new DateTime(2019, 12, 15);

output = input.QuarterOfYear(); // output = 24
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### WeekOfYear
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
int output;

input = new DateTime(2019, 5, 5);

output = input.WeekOfYear(); // output = 18

input = new DateTime(2019, 12, 15);

output = input.WeekOfYear(); // output = 50
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### Midnight
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5, 10, 10, 35);

output = input.Midnight(); // output = "05/05/2019 00:00:00"

input = new DateTime(2019, 12, 15, 13, 7, 55);

output = input.Midnight(); // output = "15/12/2019 00:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### Noon
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5, 10, 10, 35);

output = input.Noon(); // output = "05/05/2019 12:00:00"

input = new DateTime(2019, 12, 15, 13, 7, 55);

output = input.Noon(); // output = "15/12/2019 12:00:00"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### NextYearSameDay
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5, 10, 10, 35);

output = input.NextYearSameDay(); // output = "05/05/2020 10:10:35"

input = new DateTime(2019, 12, 15, 13, 7, 55);

output = input.NextYearSameDay(); // output = "15/12/2020 13:07:55"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### PreviousYearSameDay
```C#
//using Aqua.DateTimeHelpers;

DateTime input;
DateTime output;

input = new DateTime(2019, 5, 5, 10, 10, 35);

output = input.PreviousYearSameDay(); // output = "05/05/2018 10:10:35"

input = new DateTime(2019, 12, 15, 13, 7, 55);

output = input.PreviousYearSameDay(); // output = "15/12/2018 13:07:55"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### AgeCalenderYears
```C#
//using Aqua.DateTimeHelpers;

DateTime referenceDay;
DateTime today;
int output;

referenceDay = new DateTime(1970, 5, 5, 10, 10, 35);
today = new DateTime(2019, 11, 11);

output = DateTimeHelpers.AgeCalenderYears(referenceDay, today); // output = 49

referenceDay = new DateTime(1975, 12, 5, 10, 10, 35);
today = new DateTime(2019, 11, 11);

output = DateTimeHelpers.AgeCalenderYears(referenceDay, today);  // output = 44
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### AgeMonths
```C#
//using Aqua.DateTimeHelpers;

DateTime referenceDay;
DateTime today;
int output;

referenceDay = new DateTime(1970, 5, 5, 10, 10, 35);
today = new DateTime(2019, 11, 11);

output = DateTimeHelpers.AgeMonths(referenceDay, today); // output = 594

referenceDay = new DateTime(1975, 12, 5, 10, 10, 35);
today = new DateTime(2019, 11, 11);

output = DateTimeHelpers.AgeMonths(referenceDay, today);  // output = 527
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### AgeExactYears
```C#
//using Aqua.DateTimeHelpers;

DateTime referenceDay;
DateTime today;
decimal output;

referenceDay = new DateTime(1970, 5, 5, 10, 10, 35);
today = new DateTime(2019, 11, 11);

output = DateTimeHelpers.AgeExactYears(referenceDay, today); // output = 49.5

referenceDay = new DateTime(1975, 12, 5, 10, 10, 35);
today = new DateTime(2019, 11, 11);

output = DateTimeHelpers.AgeExactYears(referenceDay, today);  // output = 43.92
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### SetTime
```C#
//using Aqua.DateTimeHelpers;

DateTime referenceDay;
int inputHour;
int inputMinute;
int inputSecond;
DateTime output;

referenceDay = new DateTime(1970, 5, 5, 10, 10, 35);
inputHour = 5;
inputMinute = 5;
inputSecond = 45;

output = DateTimeHelpers.SetTime(referenceDay, inputHour, inputMinute, inputSecond); // "05/05/1970 05:05:45"

referenceDay = new DateTime(1975, 12, 5, 10, 10, 35);
inputHour = 15;
inputMinute = 5;
inputSecond = 45;

output = DateTimeHelpers.SetTime(referenceDay, inputHour, inputMinute, inputSecond); // "15/05/1975 10:10:35"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### SetDay
```C#
 //using Aqua.DateTimeHelpers;

DateTime referenceDay;
int day;
DateTime output;

referenceDay = new DateTime(1970, 5, 03, 05, 05, 45);
day = 17;

output = DateTimeHelpers.SetDay(referenceDay, day); // "17/05/1970 05:05:45"

referenceDay = new DateTime(1975, 12, 5, 10, 10, 35);
day = 22;

output = DateTimeHelpers.SetDay(referenceDay, day); // "22/12/1975 10:10:35"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### SetMonth
```C#
//using Aqua.DateTimeHelpers;

DateTime referenceDay;
int month;
DateTime output;

referenceDay = new DateTime(1970, 5, 17, 05, 05, 45);
month = 3;

output = DateTimeHelpers.SetMonth(referenceDay, month); // "17/03/1970 05:05:45"

referenceDay = new DateTime(1975, 12, 22, 10, 10, 35);
month = 10;

output = DateTimeHelpers.SetMonth(referenceDay, month); // "22/10/1975 10:10:35"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

### SetYear
```C#
//using Aqua.DateTimeHelpers;

DateTime referenceDay;
int year;
DateTime output;

referenceDay = new DateTime(1970, 3, 17, 05, 05, 45);
year = 1980;

output = DateTimeHelpers.SetYear(referenceDay, year); // "17/03/1980 05:05:45"

referenceDay = new DateTime(1975, 10, 22, 10, 10, 35);
year = 2019;

output = DateTimeHelpers.SetYear(referenceDay, year); // "22/10/2019 10:10:35"
```
:back:[Back to the Full List of Features](#List-Of-Features-and-Methods)

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)
