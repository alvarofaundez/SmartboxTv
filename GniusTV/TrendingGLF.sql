/*drop table tbl_channel;*/

/*==============================================================*/
/* Table: tbl_channel                                           */
/*==============================================================*/
/*create table tbl_channel (
   idchannel            serial not null,
   channelname          varchar(100)         null,
   channelcallletter    varchar(15)          null,
   channelnumber        numeric              null,
   constraint pk_tbl_channel primary key (idchannel)
);*/

drop table tbl_ChannelHashtag;

/*==============================================================*/
/* Table: tbl_channelhashtag                                    */
/*==============================================================*/
create table tbl_ChannelHashtag (
   idChannelHashtag     serial not null,
   idChannel            numeric              null,
   channelHashtagText   varchar(140)         null,
   constraint pk_tbl_channelhashtag primary key (idChannelHashtag)
);

alter table tbl_ChannelHashtag
   add constraint fk_tbl_chan_reference_tbl_chan foreign key (idChannel)
      references tbl_Channel (idChannel)
      on delete restrict on update restrict;

drop table tbl_Timeslice;

/*==============================================================*/
/* Table: tbl_timeslice                                         */
/*==============================================================*/
create table tbl_Timeslice (
   idTimeslice          serial not null,
   timesliceDateFrom    date                 null,
   timesliceTimeFrom    time                 null,
   timesliceDateTo      date                 null,
   timesliceTimeTo      time                 null,
   constraint pk_tbl_timeslice primary key (idtimeslice)
);

drop table tbl_Twit;

/*==============================================================*/
/* Table: tbl_twit                                              */
/*==============================================================*/
create table tbl_Twit (
   idTwit               serial not null,
   idTimeslice          numeric              null,
   idChannel            numeric              null,
   twitTwitId           varchar(50)          null,
   twitOwnerUsername    varchar(100)         null,
   twitGeo              numeric              null,
   twitCreatedDate      date                 null,
   twitCreatedTime      time                 null,
   twitHashtagsUsed     text                 null,
   twitText             varchar(140)         null,
   constraint pk_tbl_twit primary key (idTwit)
);

alter table tbl_Twit
   add constraint fk_tbl_twit_reference_tbl_time foreign key (idTimeslice)
      references tbl_Timeslice (idTimeslice)
      on delete restrict on update restrict;

alter table tbl_Twit
   add constraint fk_tbl_twit_reference_tbl_chan foreign key (idChannel)
      references tbl_channel (idChannel)
      on delete restrict on update restrict;



//////////////////////////////////////////////////////

create table tbl_ChannelHashtag (
   idChannelHashtag     serial not null,
   idChannel            numeric              null,
   channelHashtagText   varchar(140)         null,
   constraint pk_tbl_channelhashtag primary key (idChannelHashtag)
);

alter table tbl_ChannelHashtag
   add constraint fk_tbl_chan_reference_tbl_chan foreign key (idChannel)
      references tbl_Channel (idChannel)
      on delete restrict on update restrict;

create table tbl_Timeslice (
   idTimeslice          serial not null,
   timesliceDateFrom    date                 null,
   timesliceTimeFrom    time                 null,
   timesliceDateTo      date                 null,
   timesliceTimeTo      time                 null,
   constraint pk_tbl_timeslice primary key (idtimeslice)
);

create table tbl_Twit (
   idTwit               serial not null,
   idTimeslice          numeric              null,
   idChannel            numeric              null,
   twitTwitId           varchar(50)          null,
   twitOwnerUsername    varchar(100)         null,
   twitGeo              numeric              null,
   twitCreatedDate      date                 null,
   twitCreatedTime      time                 null,
   twitHashtagsUsed     text                 null,
   twitText             varchar(140)         null,
   constraint pk_tbl_twit primary key (idTwit)
);

alter table tbl_Twit
   add constraint fk_tbl_twit_reference_tbl_time foreign key (idTimeslice)
      references tbl_Timeslice (idTimeslice)
      on delete restrict on update restrict;

alter table tbl_Twit
   add constraint fk_tbl_twit_reference_tbl_chan foreign key (idChannel)
      references tbl_Channel (idChannel)
      on delete restrict on update restrict;