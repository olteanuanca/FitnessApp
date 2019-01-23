
use MyFit

alter table Accounts
drop constraint [FK__Accounts__id_Acc__36470DEF]    --drop fk id_Account_Diary; replace the name between [ ]

alter table Accounts
drop column [id_Account_Diary]


--select * from Accounts

--select * from Diary

alter table Diary
add id_Account int not null


alter table Diary
add foreign key (id_Account) references Accounts(id_Account)