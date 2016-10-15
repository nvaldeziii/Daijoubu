
create table tbl_user_settings(
	name varchar(254),
	info varchar(254)
);

create table tbl_us_cardknN5Dt(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
        CorrectCount int,
        MistakeCount int,
        LastView varchar(254)
);
insert into tbl_us_cardknN5Dt values (null,0,0,0);
create table tbl_user_card_vocab_N5data(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
        CorrectCount int,
        MistakeCount int,
        LastView varchar(254)
);

create table tbl_user_card_kana_N4Data(
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

