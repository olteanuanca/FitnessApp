 
 CREATE DATABASE MyFit
ON PRIMARY (  
Name = MyFit_1,  
FileName = 'D:\DB\myfit.mdf', 
size = 10MB, -- KB, Mb, GB, TB  
maxsize = unlimited,  
filegrowth = 1GB 
), 
( 
Name = MyFit_2,  
FileName = 'D:\DB\myfit.ndf',  
size = 10MB, -- KB, Mb, GB, TB  
maxsize = unlimited, 
filegrowth = 1GB 
) 
LOG ON ( 
Name = MyFitLogs, 
FileName = 'D:\DB\logs.ldf', 
size = 10MB, -- KB, Mb, GB, TB 
maxsize = unlimited,  
filegrowth = 1024MB ) 


 --1
 CREATE TABLE BreakfastGoals(
 id_Breakfast int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Calories float CHECK(Calories >=0 ),
 Carbs float CHECK(Carbs >=0 ),
 Protein float CHECK(Protein >=0 ),
 Fat float CHECK(Fat >=0 ),
 Cholesterol float CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float CHECK(Iron >=0 )
 );

 --2
  CREATE TABLE LunchGoals(
 id_Lunch int IDENTITY(1,1) PRIMARY KEY,
 Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float  CHECK(Cholesterol >=0 ),
 Sodium float CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float CHECK(Fiber >=0 ),
 Sugars float CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float CHECK(Iron >=0 )
 );
 --3
   CREATE TABLE DinnerGoals(
 id_Dinner int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Calories float CHECK(Calories >=0 ),
 Carbs float CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float CHECK(Potassium >=0 ),
 Fiber float CHECK(Fiber >=0 ),
 Sugars float CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float CHECK(VitC >=0 ),
 Calcium float CHECK(Calcium >=0 ),
 Iron float CHECK(Iron >=0 )
 );

 --4
   CREATE TABLE Snack1Goals(
 id_Snack1 int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float CHECK(Fat >=0 ),
 Cholesterol float CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float  CHECK(Iron >=0 )
 );
 --5
   CREATE TABLE Snack2Goals(
 id_Snack2 int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float  CHECK(Cholesterol >=0 ),
 Sodium float CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float CHECK(Calcium >=0 ),
 Iron float  CHECK(Iron >=0 )
 );

 --6
 CREATE TABLE MealGoals(
 id_MealGoals int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 id_BreakfastG_MealG int  FOREIGN KEY REFERENCES BreakfastGoals(id_Breakfast),
 id_Snack1G_MealG int  FOREIGN KEY REFERENCES Snack1Goals(id_Snack1),
 id_LunchG_MealG int  FOREIGN KEY REFERENCES LunchGoals(id_Lunch),
 id_Snack2G_MealG int  FOREIGN KEY REFERENCES Snack2Goals(id_Snack2),
 id_DinnerG_MealG int  FOREIGN KEY REFERENCES DinnerGoals(id_Dinner)
 );
 --7
 CREATE TABLE NutritionGoals(
 id_NutritionGoals int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 id_NutritionG_MealG  int FOREIGN KEY REFERENCES MealGoals(id_MealGoals),
 CaloriesPerDay float  CHECK(CaloriesPerDay >=0 ),
 CarbsPerDay float  CHECK(CarbsPerDay >=0 ),
 ProteinPerDay float  CHECK(ProteinPerDay >=0 ),
 FatPerDay float CHECK(FatPerDay >=0 ),
 CholesterolPerDay float CHECK(CholesterolPerDay >=0 ),
 SodiumPerDay float  CHECK(SodiumPerDay >=0 ),
 PotassiumPerDay float CHECK(PotassiumPerDay >=0 ),
 FiberPerDay float  CHECK(FiberPerDay >=0 ),
 SugarsPerDay float  CHECK(SugarsPerDay >=0 ),
 VitAPerDay float CHECK(VitAPerDay >=0 ),
 VitCPerDay float  CHECK(VitCPerDay >=0 ),
 CalciumPerDay float  CHECK(CalciumPerDay >=0 ),
 IronPerDay float  CHECK(IronPerDay >=0 )
 );
 --8

 CREATE TABLE WeightGoals(
 id_WeightGoals int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 StartingWeight float  CHECK(StartingWeight >=0 ),
 CurrentWeight float CHECK(CurrentWeight >=0 ),
 GoalWeight float  CHECK(GoalWeight >=0 ),
 WeeklyGoal float  CHECK(WeeklyGoal >=0 ),
 ActivityLevel int  CHECK(ActivityLevel >=0 )
 );
 --9
 CREATE TABLE FitnessGoals(
 id_FitnessGoals int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 WorkoutsPerWeek int  CHECK(WorkoutsPerWeek >=0 ),
 MinutesPerWorkout int  CHECK(MinutesPerWorkout >=0 ),
 CaloriesPerWorkout int  CHECK(CaloriesPerWorkout >=0 )
 );
 --10
 CREATE TABLE Goals(
 id_Goals int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 id_Goals_FitnessG int NOT NULL FOREIGN KEY REFERENCES FitnessGoals(id_FitnessGoals),
 id_Goals_WeightG int NOT NULL FOREIGN KEY REFERENCES WeightGoals(id_WeightGoals),
 id_Goals_Nutrition int NOT NULL FOREIGN KEY REFERENCES NutritionGoals(id_NutritionGoals)
 );
 --11
 CREATE TABLE Progress(
 id_Progress int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 pDate date,
 pWeight float  CHECK(pWeight >=0 ),
 pWaist float  CHECK(pWaist >=0 ),
 pHips float CHECK(pHips >=0 ),
 pLegs float CHECK(pLegs >=0 ),
 pBut float  CHECK(pBut >=0 ),
 pPhoto varbinary(MAX) 
 );
 --12
 CREATE TABLE MyMeals (
 id_myMeal int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Name varchar(MAX) ,
 Photo varbinary(MAX),
 Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float  CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float  CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float  CHECK(Iron >=0 )
 );
 --13
 CREATE TABLE MyRecipes(
 id_myRecipe int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Name varchar(MAX),
 Photo varbinary(MAX),
 Servings float  CHECK(Servings >=0 ),
 Reciepe_Description varchar(MAX),
 Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float  CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float  CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float  CHECK(Iron >=0 )

 );
 --14
 CREATE TABLE MyCardio(
 id_myCardio int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Cardio_Description varchar(MAX) ,
 Duration_min int CHECK(Duration_min >=0),
 Calories_burned int  CHECK(Calories_burned >=0) 
 );
 --15
 CREATE TABLE MyStrength(
 id_myStrength int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 MyStrength_Description varchar(max),
 NbOfSets int  CHECK(NbOfSets >=0 ),
 RepsPerSet int  CHECK(RepsPerSet >=0),
 WeightPerRep int CHECK(WeightPerRep >=0),
 Calories_burned int CHECK(Calories_burned >=0)
 );
 
  --17
 CREATE TABLE Ingredients(
 id_ingredient int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Name varchar(max) ,
Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float  CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float  CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float  CHECK(Iron >=0 )
 );


 --19
 CREATE TABLE Cardio(
 id_Cardio int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Cardio_Description varchar(MAX) ,
 Duration_min int  CHECK(Duration_min >=0),
 Calories_burned int CHECK(Calories_burned >=0) 
 );

 --20
  CREATE TABLE Strength(
 id_Strength int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Strength_Description varchar(max),
 NbOfSets int  CHECK(NbOfSets >=0 ),
 RepsPerSet int CHECK(RepsPerSet >=0),
 WeightPerRep int CHECK(WeightPerRep >=0),
 Calories_burned int  CHECK(Calories_burned >=0)
 );


 --21
 CREATE TABLE DiaryBreakfast(
 id_DiaryBreakfast int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Name varchar(max) ,
 Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float  CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float  CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float  CHECK(Iron >=0 )
 );

 --22
 CREATE TABLE DiarySnack1(
 id_DiarySnack1 int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Name varchar(max) ,
Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float  CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float  CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float  CHECK(Iron >=0 )
 );

 --23
  CREATE TABLE DiaryLunch(
 id_DiaryLunch int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Name varchar(max) ,
 Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float  CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float  CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float  CHECK(Iron >=0 )
 );

 --24
  CREATE TABLE DiarySnack2(
 id_DiarySnack2 int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Name varchar(max) ,
Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float  CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float  CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float  CHECK(Iron >=0 )
 );

 --25  
 CREATE TABLE DiaryDinner(
 id_DiaryDinner int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Name varchar(max) ,
Calories float  CHECK(Calories >=0 ),
 Carbs float  CHECK(Carbs >=0 ),
 Protein float  CHECK(Protein >=0 ),
 Fat float  CHECK(Fat >=0 ),
 Cholesterol float  CHECK(Cholesterol >=0 ),
 Sodium float  CHECK(Sodium >=0 ),
 Potassium float  CHECK(Potassium >=0 ),
 Fiber float  CHECK(Fiber >=0 ),
 Sugars float  CHECK(Sugars >=0 ),
 VitA float  CHECK(VitA >=0 ),
 VitC float  CHECK(VitC >=0 ),
 Calcium float  CHECK(Calcium >=0 ),
 Iron float  CHECK(Iron >=0 )
 );
 --26
 CREATE TABLE DiaryCardio(
 id_DiaryCardio int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Cardio_Description varchar(MAX) ,
 Duration_min int  CHECK(Duration_min >=0),
 Calories_burned int CHECK(Calories_burned >=0) 
 );
 --27
   CREATE TABLE DiaryStrength(
 id_DiaryStrength int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Strength_Description varchar(max),
 NbOfSets int  CHECK(NbOfSets >=0 ),
 RepsPerSet int CHECK(RepsPerSet >=0),
 WeightPerRep int CHECK(WeightPerRep >=0),
 Calories_burned int  CHECK(Calories_burned >=0)
 );

 --28
 CREATE TABLE DiaryWater(
 id_DiaryWater int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Quantity_ml int CHECK(Quantity_ml >=0)
 );

 --29
 CREATE TABLE DiaryNotes(
 id_DiaryNotes int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 Note varchar(max)  ,
 NoteType varchar(max) 
 );

 --30
 CREATE TABLE DiaryEntry(
 id_DiaryEntry int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 DiaryDate date NOT NULL,
 id_DEntry_DBreakfast int NOT NULL FOREIGN KEY REFERENCES DiaryBreakfast(id_DiaryBreakfast),
 id_DEntry_DSnack1 int NOT NULL FOREIGN KEY REFERENCES DiarySnack1(id_DiarySnack1),
 id_DEntry_DLunch int NOT NULL FOREIGN KEY REFERENCES DiaryLunch(id_DiaryLunch),
 id_DEntry_DSnack2 int NOT NULL FOREIGN KEY REFERENCES DiarySnack2(id_DiarySnack2),
 id_DEntry_DDinner int NOT NULL FOREIGN KEY REFERENCES DiaryDinner(id_DiaryDinner),
 id_DEntry_DCardio int NOT NULL FOREIGN KEY REFERENCES DiaryCardio(id_DiaryCardio),
 id_DEntry_DStrength int NOT NULL FOREIGN KEY REFERENCES DiaryStrength(id_DiaryStrength),
 id_DEntry_DWater int NOT NULL FOREIGN KEY REFERENCES DiaryWater(id_DiaryWater),
 id_DEntry_DNotes int NOT NULL FOREIGN KEY REFERENCES DiaryNotes(id_DiaryNotes)
);

--31
CREATE TABLE Diary(
id_Diary int IDENTITY(1,1) NOT NULL PRIMARY KEY,
id_Diary_Entry int NOT NULL FOREIGN KEY REFERENCES DiaryEntry(id_DiaryEntry)
);

--32
CREATE TABLE Reminder(
id_Reminder int IDENTITY(1,1) NOT NULL PRIMARY KEY,
ReminderDescription varchar(max) ,
ReminderTime time(0)
);

--33
CREATE TABLE FriendRequest(
id_FriendRequest int IDENTITY(1,1) NOT NULL PRIMARY KEY,
fromUsername varchar(200),
toUsername varchar(200),
);
--34
CREATE TABLE FriendMessage(
id_FriendMessage int IDENTITY(1,1) NOT NULL PRIMARY KEY,
fromUsername varchar(200),
toUsername varchar(200),
Message varchar(max)
);

--35
CREATE TABLE Friends(
id_Friend int IDENTITY(1,1) NOT NULL PRIMARY KEY,
EmailAddress varchar(max),
Username varchar(200)
);


--36
CREATE TABLE Posts(
id_Post int IDENTITY(1,1) NOT NULL PRIMARY KEY,
FromId int,
PostDate datetime ,
Content varchar(max) ,
Photo varbinary(max)
);
--38
CREATE TABLE AccountCredentials(
id_AccCredentials int IDENTITY(1,1) NOT NULL PRIMARY KEY,
AccUsername varchar(max) NOT NULL,
AccPassword varchar(max) NOT NULL,
AccEmail varchar(max),
);
--39
CREATE TABLE Notifications(
id_Notification int IDENTITY(1,1) NOT NULL PRIMARY KEY,
NotDate datetime,
NotDescription varchar(max) ,
);


--37
CREATE TABLE Accounts(
id_Account int IDENTITY(1,1) NOT NULL PRIMARY KEY,
FirstName varchar(255) NOT NULL,
LastName varchar(255) NOT NULL,
BirthDate date NOT NULL,
Age int NOT NULL CHECK(Age>=0),
Height float NOT NULL CHECK(Height >=0),
Email varchar(255) NOT NULL,
Gender varchar(255) NOT NULL,
Photo varbinary(max),
Username varchar(max),
id_Account_Diary int NOT NULL FOREIGN KEY REFERENCES Diary(id_Diary),
id_Account_Goals int NOT NULL FOREIGN KEY REFERENCES Goals(id_Goals),
id_Account_AccountCredentials int NOT NULL FOREIGN KEY REFERENCES AccountCredentials(id_AccCredentials),
id_Account_Progress int NOT NULL FOREIGN KEY REFERENCES Progress(id_Progress),


);

CREATE TABLE Accounts_Notification
(
id_Acc_Notification int IDENTITY(1,1) NOT NULL PRIMARY KEY,
id_Account int FOREIGN KEY REFERENCES Accounts(id_Account),
id_Notification int FOREIGN KEY REFERENCES Notifications(id_Notification),
);


CREATE TABLE Accounts_Reminder
(
id_Acc_Reminder int IDENTITY(1,1) NOT NULL PRIMARY KEY,
id_Account int FOREIGN KEY REFERENCES Accounts(id_Account),
id_Reminder int FOREIGN KEY REFERENCES Reminder(id_Reminder),
);

CREATE TABLE Accounts_Friends
(
id_Acc_Friends int IDENTITY(1,1) NOT NULL PRIMARY KEY,
id_Account int FOREIGN KEY REFERENCES Accounts(id_Account),
id_Friends int FOREIGN KEY REFERENCES Friends(id_Friend),
);


CREATE TABLE Accounts_Meals
(
id_Acc_Meals int IDENTITY(1,1) NOT NULL PRIMARY KEY,
id_Account int FOREIGN KEY REFERENCES Accounts(id_Account),
id_Meals int FOREIGN KEY REFERENCES MyMeals(id_myMeal),
);


CREATE TABLE Accounts_Recipes
(
id_Acc_Recipes int IDENTITY(1,1) NOT NULL PRIMARY KEY,
id_Account int FOREIGN KEY REFERENCES Accounts(id_Account),
id_MyRecipes int FOREIGN KEY REFERENCES MyRecipes(id_myRecipe),
);


CREATE TABLE Accounts_Cardio
(
id_Acc_Cardio int IDENTITY(1,1) NOT NULL PRIMARY KEY,
id_Account int FOREIGN KEY REFERENCES Accounts(id_Account),
id_Cardio int FOREIGN KEY REFERENCES MyCardio(id_myCardio),
);


CREATE TABLE Accounts_Strength
(
id_Acc_Strength int IDENTITY(1,1) NOT NULL PRIMARY KEY,
id_Account int FOREIGN KEY REFERENCES Accounts(id_Account),
id_Strength int FOREIGN KEY REFERENCES MyStrength(id_myStrength),
);


