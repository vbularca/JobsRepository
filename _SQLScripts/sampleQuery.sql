Truncate Table Jobs;
GO

Insert Into Jobs(Name, ChangedDate, Type, IsProcessed, Reason)
values
 ('test1', GetDate(), 1, 0, 'I want so'), 
 ('test2', GetDate(), 2, 0, 'I want so'), 
 ('test3', GetDate(), 3, 0, 'I want so'), 
 ('test4', GetDate(), 1, 0, 'I want so');
 
Insert Into Jobs(Name, ChangedDate, Type)
values
 ('test5', GetDate(), 1), 
 ('test6', GetDate(), 2), 
 ('test7', GetDate(), 3), 
 ('test8', GetDate(), 1);
 
 Select * From Jobs