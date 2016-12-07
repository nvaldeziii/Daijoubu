
create table tbl_user_settings(
	name varchar(254),
	info varchar(254)
);
insert into tbl_user_settings values ("AnswerFeedBackDelay","1500");
insert into tbl_user_settings values ("QuestionBufferCount","5");
insert into tbl_user_settings values ("TypingQuizCorrectnessAdder","2");
insert into tbl_user_settings values ("QueueCount","5");

insert into tbl_user_settings values ("ForceEnableN4","False");
insert into tbl_user_settings values ("EnableN4","False");

insert into tbl_user_settings values ("HapticFeedback","True");
insert into tbl_user_settings values ("SpeakWords","True");

insert into tbl_user_settings values ("lesson_prog_hiragana","0");
insert into tbl_user_settings values ("lesson_prog_katakana","0");
insert into tbl_user_settings values ("lesson_prog_n5vocab","0");
insert into tbl_user_settings values ("lesson_prog_n4vocab","0");
insert into tbl_user_settings values ("lesson_prog_n4grammar","0");
insert into tbl_user_settings values ("lesson_prog_introduction","0");

create table tbl_us_cardknN5Dt(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
        CorrectCount int,
        MistakeCount int,
        LastView varchar(254)
);
insert into tbl_us_cardknN5Dt values (null,0,0,0);

create table tbl_us_cardktknN5Dt(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
        CorrectCount int,
        MistakeCount int,
        LastView varchar(254)
);
insert into tbl_us_cardktknN5Dt values (null,0,0,0);

create table tbl_us_cardvbN5dt(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
        CorrectCount int,
        MistakeCount int,
        LastView varchar(254)
);

create table tbl_us_cardvbN4dt(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
        CorrectCount int,
        MistakeCount int,
        LastView varchar(254)
);

create table tbl_us_cardgrN4dt(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
        CorrectCount int,
        MistakeCount int,
        LastView varchar(254)
);

create table tbl_us_cardknN4Dt(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
        CorrectCount int,
        MistakeCount int,
        LastView varchar(254)
		
);create table tbl_us_cardktknN4Dt(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
        CorrectCount int,
        MistakeCount int,
        LastView varchar(254)
);

create table tbl_user_card_vocab_N4data(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
        CorrectCount int,
        MistakeCount int,
        LastView varchar(254)
);

