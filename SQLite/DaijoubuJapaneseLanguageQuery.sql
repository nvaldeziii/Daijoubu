-- Daijoubu sqlite3 queries
-- DaijoubuJapaneseLanguage.sqlite3;

create table tbl_vocabulary_N5(
	Id int CONSTRAINT constraint_name PRIMARY KEY,
	romaji varchar(254),
	kanji varchar(254),
	meaning varchar(254)
);

create table tbl_vocabulary_N4(
	Id int CONSTRAINT constraint_name PRIMARY KEY,
	romaji varchar(254),
	kanji varchar(254),
	meaning varchar(254)
);

create table tbl_grammar_N5(
	Id int CONSTRAINT constraint_name PRIMARY KEY,
	sentence_en varchar(254),
	sentence_jp varchar(254),
	sentence_ro varchar(254)
);

create table tbl_grammar_N4(
	Id int CONSTRAINT constraint_name PRIMARY KEY,
	sentence_en varchar(254),
	sentence_jp varchar(254),
	sentence_ro varchar(254)
);

create table tbl_kana(
	Id int CONSTRAINT constraint_name PRIMARY KEY,
	hiragana varchar(9),
	katakana varchar(9),
	romaji varchar(9)
);

insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"a","あ","ア");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ka","か","カ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"sa","さ","サ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ta","た","タ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"na","な","ナ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"i","い","イ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ki","き","キ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"shi","し","シ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"chi","ち","チ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ni","に","ニ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"u","う","ウ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ku","く","ク");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"su","す","ス");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"tsu","つ","ツ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"nu","ぬ","ヌ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"e","え","エ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ke","け","ケ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"se","せ","セ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"te","て","テ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ne","ね","ネ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"o","お","オ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ko","こ","コ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"so","そ","ソ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"to","と","ト");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"no","の","ノ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ha","は","ハ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ma","ま","マ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ya","や","ヤ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ra","ら","ラ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"wa","わ","ワ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"hi","ひ","ヒ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"mi","み","ミ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ri","り","リ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"wi","ゐ","ヰ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"fu","ふ","フ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"mu","む","ム");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"yu","ゆ","ユ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ru","る","ル");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"n","ん","ン");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"he","へ","ヘ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"me","め","メ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"re","れ","レ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"we","ゑ","ヱ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ho","ほ","ホ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"mo","も","モ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"yo","よ","ヨ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ro","ろ","ロ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"wo","を","ヲ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ga","が","ガ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"za","ざ","ザ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"da","だ","ダ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ba","ば","バ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"pa","ぱ","パ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"gi","ぎ","ギ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ji","じ","ジ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ji","ぢ","ヂ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"bi","び","ビ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"pi","ぴ","ピ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"gu","ぐ","グ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"zu","ず","ズ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"zu","づ","ヅ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"bu","ぶ","ブ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"pu","ぷ","プ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ge","げ","ゲ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ze","ぜ","ゼ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"de","で","デ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"be","べ","ベ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"pe","ぺ","ペ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"go","ご","ゴ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"zo","ぞ","ゾ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"do","ど","ド");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"bo","ぼ","ボ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"po","ぽ","ポ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"kya","きゃ","キャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"sha","しゃ","シャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"cha","ちゃ","チャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"hya","ひゃ","ヒャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"pya","ぴゃ","ピャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"kyu","きゅ","キュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"shu","しゅ","シュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"chu","ちゅ","チュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"hyu","ひゅ","ヒュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"pyu","ぴゅ","ピュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"kyo","きょ","キョ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"sho","しょ","ショ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"cho","ちょ","チョ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"hyo","ひょ","ヒョ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"pyo","ぴょ","ピョ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"gya","ぎゃ","ギャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ja","じゃ","ジャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"nya","にゃ","ニャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"bya","びゃ","ビャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"mya","みゃ","ミャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"gya","ぎゅ","ギュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ju","じゅ","ジュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"nyu","にゅ","ニュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"byu","びゅ","ビュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"my","みゅ","ミュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"gyo","ぎょ","ギョ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"jo","じょ","ジョ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"nyo","にょ","ニョ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"byo","びょ","ビョ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"myo","みょ","ミョ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"rya","りゃ","リャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ryu","りゅ","リュ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ryu","りょ","リョ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ja","ぢゃ","ヂャ");
insert into tbl_kana (Id,romaji,hiragana,katakana) values (null,"ju","ぢゅ","ヂュ");

