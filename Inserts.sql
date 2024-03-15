--
-- PostgreSQL database dump
--

-- Dumped from database version 11.18 (Debian 11.18-1.pgdg100+1)
-- Dumped by pg_dump version 15.1 (Debian 15.1-1.pgdg100+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Data for Name: t_e_categorieaccessoire_cta; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_categorieaccessoire_cta VALUES (1, 'Design');
INSERT INTO "BMWMottorad".t_e_categorieaccessoire_cta VALUES (2, 'Confort & Ergonomie');
INSERT INTO "BMWMottorad".t_e_categorieaccessoire_cta VALUES (3, 'Bagagerie');
INSERT INTO "BMWMottorad".t_e_categorieaccessoire_cta VALUES (4, 'Navigation & Communication');
INSERT INTO "BMWMottorad".t_e_categorieaccessoire_cta VALUES (5, 'Sécurité');


--
-- Data for Name: t_e_gammemoto_gam; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_gammemoto_gam VALUES (1, 'Sport');
INSERT INTO "BMWMottorad".t_e_gammemoto_gam VALUES (2, 'M');
INSERT INTO "BMWMottorad".t_e_gammemoto_gam VALUES (3, 'Tour');
INSERT INTO "BMWMottorad".t_e_gammemoto_gam VALUES (4, 'Roadster');
INSERT INTO "BMWMottorad".t_e_gammemoto_gam VALUES (5, 'Heritage');
INSERT INTO "BMWMottorad".t_e_gammemoto_gam VALUES (6, 'Adventure');
INSERT INTO "BMWMottorad".t_e_gammemoto_gam VALUES (19, 'Compétition');


--
-- Data for Name: t_e_modelemoto_mod; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_modelemoto_mod VALUES (1, 1, 'S 1000 RR', 'La RR est désormais encore plus concentrée et plus précise sur les performances pures. Pour tous ceux qui en veulent toujours plus. D’eux-mêmes. De chaque tour de piste. Et de leur RR. Dans l’esprit de  #NeverStopChallenging. C’est précisément là où la RR se déplace depuis toujours que la conduite est un travail au millimètre. C’est pourquoi nous avons affûté et perfectionné la RR aux endroits décisifs : du nouveau capteur d’angle de braquage avec Brake Slide Assist et Slide Control, ainsi que l’intégration de composants M, jusqu’aux gestes décisifs pour la transformation de la moto pour la piste, en passant par des améliorations dans l’électronique. Et tout cela avec un objectif clair : de nouvelles pole positions. ', 20740);
INSERT INTO "BMWMottorad".t_e_modelemoto_mod VALUES (2, 3, 'K 1600 GTL', 'Un proverbe dit : « Quiconque voyage avec exigence ne voyagera jamais seul. » C’est d’autant plus vrai si vous êtes accompagné. La BMW K 1600 GTL représente les deux. Elle offre des performances touristiques qui ne laissent rien à désirer. Son puissant six-cylindres offre désormais encore plus de dynamisme et de souveraineté : grâce à la géométrie confortable du véhicule, vous pouvez profiter pleinement de chaque kilomètre. Le cockpit a été entièrement repensé. Pour que vous puissiez profiter de chaque sortie de manière encore plus consciente et intensive, il est entièrement orienté vers l’interaction avec le conducteur. Parce que c’est ici que commence le voyage à deux – fidèle à l’esprit de #RideAndShare.', 30790);
INSERT INTO "BMWMottorad".t_e_modelemoto_mod VALUES (3, 5, 'R 18 Classic', 'La R 18 Classic est une véritable moto routière. Elle n''est pas sans rappeler l''âme des premiers cruisers carénés, faits pour avaler les longues routes qui jalonnent le continent américain. Mais la R 18 Classic est une BMW avant tout : elle reprend des éléments intemporels de notre histoire. Le moteur boxer le plus puissant que nous ayons jamais construit constitue le cœur même de cette moto : il évoque chez nous le plaisir de l''évasion, les paysages qui défilent, les longues virées en toute décontraction', 23990);
INSERT INTO "BMWMottorad".t_e_modelemoto_mod VALUES (4, 6, 'F 800 GS', 'Qui dit trajet dit également fiabilité. Avec son nouveau moteur puissant et de nombreuses autres nouveautés, la F 800 GS est le compagnon de voyage idéal pour toutes vos excursions. Préparez vos bagages, allez chercher vos amis et c’est parti. Vous découvrirez ensemble de nouvelles routes et vivrez des aventures inoubliables. Vous ressentirez le #SpiritOfGS au plus près, écouterez le crépitement du feu de camp et laisserez le quotidien loin derrière vous.', 11290);


--
-- Data for Name: t_e_accessoire_acc; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_accessoire_acc VALUES (1, 1, 1, 'Silencieux arrière Sport en titane', 1011, 'Le nec plus ultra du haut de gamme : Le silencieux arrière slip-on Sport en titane haute qualité avec capuchon d’extrémité en carbone délivre un son rauque et souligne l’esthétique sportive. Le poids du silencieux Sport développé par Akrapovič a également été optimisé par rapport au silencieux de série.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19mfNpaD0EUNAoXsbaDWF9%25UcX0%25l7wVG8YCmw1pC4L9Q48E5lkboMGE2pG');
INSERT INTO "BMWMottorad".t_e_accessoire_acc VALUES (4, 2, 3, 'Sac arrière Adventure Collection petit format', 226, 'Le petit sac arrière Adventure Collection en nylon résistant est extensible de 37 à 45 litres : parfait pour les excursions courtes. Il peut être monté avec des sangles sur le porte-bagages ou la selle passager. Le sac arrière peut également être utilisé comme sac à dos ou sac à bandoulière. Rangement compact lorsqu’il n’est pas utilisé.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19mfNpaD0EUNAoXsbaDWF9%25UcX0%25l7wVG8Ygmw1p%25dz3GtUDvJdoVO7q4OezWNRDm6hz9oh');
INSERT INTO "BMWMottorad".t_e_accessoire_acc VALUES (6, 4, 3, 'Sac arrière Black Collection, petit format', 226, 'Le sac arrière Black Collection se caractérise par des détails astucieux, tels qu’une poche intérieure amovible étanche à l’eau et des sangles d’épaule ajustables permettant une utilisation comme sac à dos. L’espace de rangement peut être étendu de 35 à 42 litres et fait de ce sac totalement repliable à l’exception du fond rigide un compagnon idéal pour les excursions plus courtes.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19mfNpaD0EUNAoXsbaDWF9%25UcX0%25l7wVG8YLqw1p%25dz3GtUDvJdoVO7q4OezWNRDm6hz9oh');
INSERT INTO "BMWMottorad".t_e_accessoire_acc VALUES (7, 2, 4, 'ConnectedRide Navigator', 696, 'Avec le BMW ConnectedRide Navigator, tous les trajets et les plans se trouvent en permanence à disposition. Le BMW ID permet de synchroniser les itinéraires planifiés et les enregistrements avec l’application BMW Motorrad. L’écran tactile 5,5" est facile à lire, même en plein soleil. Son utilisation est intuitive grâce au multicontrôleur.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19mfNpaD0EUNAoXsbaDWF9%25UcX0%25l7wVG8XVUw1p%25dz3GtUDvJdoVO7q4OezWNRDm6hz9oh');
INSERT INTO "BMWMottorad".t_e_accessoire_acc VALUES (8, 3, 5, 'Grille de protection de phare', 139, 'Lors des sorties enduro très techniques, le solide protecteur de phare protège efficacement le phare à LED contre les dommages. Une fois l’adaptateur fourni installé, le protecteur de phare en polycarbonate peut être monté et démonté du phare en quelques secondes.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19mfNpaD0EUNAoXsbaDWF9%25UcX0%25l7wVG8Y5nw1pC4L9Q48E5lkboMGE2pG');
INSERT INTO "BMWMottorad".t_e_accessoire_acc VALUES (2, 1, 2, 'Bulle teintée', 182, 'La bulle haute teintée offre au pilote une plus grande protection contre le vent et les intempéries et convainc par son confort de conduite amélioré, même lors des longs trajets sur autoroute. L’aspect teinté souligne le look sportif de la moto et, grâce au revêtement antirayures, la bulle garde durablement sa transparence.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19mfNpaD0EUNAoXsbaDWF9%25UcX0%25l7wVG8Y5Kw1pC4L9Q48E5lkboMGE2pG');


--
-- Data for Name: t_e_pays_pay; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Albanie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Antarctique');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Samoa AmÃ©ricaines');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Andorre');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Angola');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Antigua-et-Barbuda');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('AzerbaÃ¯djan');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Argentine');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Australie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Autriche');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Bahamas');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('BahreÃ¯n');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Bangladesh');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ArmÃ©nie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Barbade');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Belgique');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Bermudes');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Bhoutan');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Bolivie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Bosnie-HerzÃ©govine');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Botswana');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽle Bouvet');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('BrÃ©sil');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Belize');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Territoire Britannique de l''OcÃ©an Indien');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Salomon');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Vierges Britanniques');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('BrunÃ©i Darussalam');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Bulgarie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Myanmar');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Burundi');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('BÃ©larus');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Cambodge');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Cameroun');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Canada');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Cap-vert');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles CaÃ¯manes');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique Centrafricaine');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Sri Lanka');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Tchad');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Chili');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Chine');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('TaÃ¯wan');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽle Christmas');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Cocos (Keeling)');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Colombie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Comores');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Mayotte');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique du Congo');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique DÃ©mocratique du Congo');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Cook');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Costa Rica');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Croatie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Cuba');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Chypre');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique TchÃ¨que');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('BÃ©nin');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Danemark');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Dominique');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique Dominicaine');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Ã‰quateur');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('El Salvador');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('GuinÃ©e Ã‰quatoriale');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Ã‰thiopie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Ã‰rythrÃ©e');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Estonie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles FÃ©roÃ©');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles (malvinas) Falkland');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('GÃ©orgie du Sud et les ÃŽles Sandwich du Sud');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Fidji');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Finlande');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Ã…land');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Guyane FranÃ§aise');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('PolynÃ©sie FranÃ§aise');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Terres Australes FranÃ§aises');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Djibouti');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Gabon');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('GÃ©orgie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Gambie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Territoire Palestinien OccupÃ©');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Allemagne');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Ghana');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Gibraltar');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Kiribati');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('GrÃ¨ce');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Groenland');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Grenade');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Guadeloupe');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Guam');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Guatemala');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('GuinÃ©e');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Guyana');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('HaÃ¯ti');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Heard et Mcdonald');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Saint-SiÃ¨ge (Ã©tat de la CitÃ© du Vatican)');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Honduras');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Hong-Kong');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Hongrie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Islande');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Inde');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('IndonÃ©sie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique Islamique d''Iran');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Iraq');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Irlande');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('IsraÃ«l');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Italie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('CÃ´te d''Ivoire');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('JamaÃ¯que');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Japon');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Kazakhstan');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Jordanie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Kenya');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique Populaire DÃ©mocratique de CorÃ©e');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique de CorÃ©e');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('KoweÃ¯t');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Kirghizistan');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique DÃ©mocratique Populaire Lao');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Liban');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Lesotho');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Lettonie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('LibÃ©ria');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Jamahiriya Arabe Libyenne');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Liechtenstein');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Lituanie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Luxembourg');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Macao');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Madagascar');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Malawi');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Malaisie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Maldives');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Mali');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Malte');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Martinique');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Mauritanie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Maurice');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Mexique');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Monaco');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Mongolie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique de Moldova');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Montserrat');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Maroc');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Mozambique');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Oman');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Namibie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Nauru');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('NÃ©pal');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('t_e_pays_pay-Bas');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Antilles NÃ©erlandaises');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Aruba');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Nouvelle-CalÃ©donie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Vanuatu');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Nouvelle-ZÃ©lande');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Nicaragua');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Niger');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('NigÃ©ria');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('NiuÃ©');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽle Norfolk');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('NorvÃ¨ge');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Mariannes du Nord');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Mineures Ã‰loignÃ©es des Ã‰tats-Unis');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Ã‰tats FÃ©dÃ©rÃ©s de MicronÃ©sie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Marshall');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Palaos');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Pakistan');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Panama');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Papouasie-Nouvelle-GuinÃ©e');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Paraguay');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('PÃ©rou');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Philippines');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Pitcairn');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Pologne');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Portugal');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('GuinÃ©e-Bissau');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Timor-Leste');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Porto Rico');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Qatar');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©union');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Roumanie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('FÃ©dÃ©ration de Russie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Rwanda');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Sainte-HÃ©lÃ¨ne');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Saint-Kitts-et-Nevis');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Anguilla');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Sainte-Lucie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Saint-Pierre-et-Miquelon');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Saint-Vincent-et-les Grenadines');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Saint-Marin');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Sao TomÃ©-et-Principe');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Arabie Saoudite');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('SÃ©nÃ©gal');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Seychelles');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Sierra Leone');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Singapour');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Slovaquie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Viet Nam');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('SlovÃ©nie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Somalie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Afrique du Sud');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Zimbabwe');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Espagne');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Sahara Occidental');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Soudan');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Suriname');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Svalbard etÃŽle Jan Mayen');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Swaziland');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('SuÃ¨de');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Suisse');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique Arabe Syrienne');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Tadjikistan');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ThaÃ¯lande');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Togo');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Tokelau');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Tonga');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('TrinitÃ©-et-Tobago');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Ã‰mirats Arabes Unis');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Tunisie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Turquie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('TurkmÃ©nistan');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Turks et CaÃ¯ques');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Tuvalu');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Ouganda');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Ukraine');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('L''ex-RÃ©publique Yougoslave de MacÃ©doine');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Ã‰gypte');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Royaume-Uni');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽle de Man');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('RÃ©publique-Unie de Tanzanie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Ã‰tats-Unis');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('ÃŽles Vierges des Ã‰tats-Unis');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Burkina Faso');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Uruguay');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('OuzbÃ©kistan');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Venezuela');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Wallis et Futuna');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Samoa');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('YÃ©men');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Serbie-et-MontÃ©nÃ©gro');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Zambie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Algérie');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('testpays1');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('testpays2');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('France');
INSERT INTO "BMWMottorad".t_e_pays_pay VALUES ('Afghanistan');


--
-- Data for Name: t_e_adresse_adr; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (80, 'Uruguay', '69 Chemin Raynal 31200 Toulouse');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (78, 'Angola', '161 Chemin des granges 74290 Talloires-Montmin');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (79, 'Japon', '161 Chemin des granges 74290 Talloires-Montmin');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (56, 'Wallis et Futuna', '161 Chemin des Grandes Terres 83143 Le Val');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (59, 'Argentine', '68 Rue Bonnat 31400 Toulouse');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (63, 'Qatar', '161 Chemin des granges 74290 Talloires-Montmin');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (64, 'Qatar', '161 Chemin des granges 74290 Talloires-Montmin');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (67, 'Lettonie', '23 rue des Grouaisons, Arpajon');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (71, 'Suisse', '12 Chemin de Bellevue 54000 Nancy');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (73, 'Guatemala', '161 Chemin des granges 74290 Talloires-Montmin');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (81, 'Uruguay', '69 Chemin Raynal 31200 Toulouse');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (94, 'Antarctique', '9 Rue de l'' Arc-en-Ciel 74940 Annecy');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (95, 'Australie', '61 Boulevard Deltour 31500 Toulouse');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (88, 'testpays1', 'z');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (84, 'testpays1', '9 Rue de l'' Arc-en-Ciel 74940 Annecy');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (58, 'testpays1', '62 Boulevard Macdonald 75019 Paris');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (74, 'testpays1', '78 Rue Pasteur 33200 Bordeaux');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (85, 'testpays1', '9 Rue de l'' Arc-en-Ciel 74940 Annecy');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (87, 'testpays1', '161 Chemin des Grandes Terres 83143 Le Val');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (91, 'testpays1', '42 Rue des Boules 63200 Riom');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (92, 'testpays1', '42 Rue des Boules 63200 Riom');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (93, 'testpays1', '61 Boulevard Deltour 31500 Toulouse');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (68, 'testpays1', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (51, 'testpays2', '260 Allée des regains 74130 Bonneville');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (52, 'testpays2', '62 Boulevard Macdonald 75019 Paris');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (53, 'testpays2', '160 Chemin des granges 74290 Talloires-Montmin');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (54, 'testpays2', '42 Avenue de brogny 74870 Annecy');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (55, 'testpays2', '13 Chemin de Bellevue 54000 Nancy');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (57, 'testpays2', '12 rue de l''arc en ciel 82000 Montauban');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (61, 'testpays2', '260 Allée des regains 74130 Bonneville');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (62, 'testpays2', '260 Allée des regains 74130 Bonneville');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (65, 'testpays2', '161 Chemin des granges 74290 Talloires-Montmin');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (75, 'testpays2', '9, rue de l''arc en ciel');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (1, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (2, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (3, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (4, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (5, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (6, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (7, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (8, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (9, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (10, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (11, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (12, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (13, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (14, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (15, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (16, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (17, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (18, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (19, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (20, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (21, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (22, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (23, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (82, 'Australie', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (60, 'Argentine', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (83, 'Grenade', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (69, 'Gambie', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (70, 'ÃŽles Cocos (Keeling)', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (72, 'Angola', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (76, 'Australie', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (90, 'Autriche', '42 Rue des Boules 63200 Riom');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (24, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (25, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (26, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (27, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (28, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (29, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (30, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (31, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (32, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (33, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (34, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (35, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (36, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (37, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (38, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (39, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (40, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (41, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (42, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (43, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (44, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (45, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (46, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (47, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (48, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (49, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (50, 'testpays2', 'x');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (96, 'Albanie', '161 Chemin Finette 97490 Saint-Denis');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (97, 'France', '161 Chemin Finette 97490 Saint-Denis');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (98, 'France', '161 Chemin Finette 97490 Saint-Denis');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (200, 'France', '56 Rue Pelleport 33800 Bordeaux');
INSERT INTO "BMWMottorad".t_e_adresse_adr VALUES (201, 'Australie', '56 Rue Pelleport 33800 Bordeaux');


--
-- Data for Name: t_e_categoriecaracteristique_ctc; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_categoriecaracteristique_ctc VALUES (1, 'moteur');
INSERT INTO "BMWMottorad".t_e_categoriecaracteristique_ctc VALUES (2, 'performance/ consommation');
INSERT INTO "BMWMottorad".t_e_categoriecaracteristique_ctc VALUES (3, 'équipement électrique');
INSERT INTO "BMWMottorad".t_e_categoriecaracteristique_ctc VALUES (4, 'transmission');
INSERT INTO "BMWMottorad".t_e_categoriecaracteristique_ctc VALUES (5, 'châssis / freins');
INSERT INTO "BMWMottorad".t_e_categoriecaracteristique_ctc VALUES (6, 'dimensions /poids');


--
-- Data for Name: t_e_caracteristique_car; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (2, 1, 1, 'Epuration de gaz', 'Catalyseur 3 voies à régulation lambda');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (3, 1, 1, 'type', 'Moteur quatre temps à quatre cylindres en ligne et refroidissement par liquide eau/huile, quatre soupapes en titane par cylindre, distribution à calage variable BMW ShiftCam');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (4, 1, 1, 'Alésage x course', '80 mm x 49,7 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (5, 1, 1, 'Cylindrée', '999 cm³');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (6, 1, 1, 'Rapport volumétrique', '13,3 : 1');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (8, 1, 1, 'norme antipollution', 'EU 5');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (9, 1, 1, 'couple max', '113 Nm à 11 000 tr/min');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (10, 1, 2, 'vitesse maximale', '303 km/h');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (11, 1, 2, 'consommation aux 100 km', '6,4 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (12, 1, 2, 'Emissions de CO2', '149 g/km');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (13, 1, 2, 'type de carburant', 'Super plus sans plomb (5 % d''éthanol max, E5) / ROZ/RON 98 / 93 AKI');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (14, 1, 2, 'accélération de 0 à 100', '3.21 s');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (15, 1, 3, 'Alternateur', '450 W');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (16, 1, 3, 'Batterie', 'Batterie M Lightweight, 12 V / 5 Ah, lithium-ion');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (17, 1, 4, 'Embrayage', 'Bain d''huile multidisque, antidribble, avec autorenforcement');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (18, 1, 4, 'Boite de vitesse', 'Boîte 6 rapports à commande par crabots avec denture droite');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (19, 1, 4, 'transmission secondaire', 'Chaîne 525 17/46');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (20, 1, 4, 'controle antiplanage', 'BMW Motorrad DTC, slide control');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (21, 1, 5, 'cadre', 'Cadre périmétrique en aluminium, moteur à fonction porteuse');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (22, 1, 5, 'guidage de la roue avant', 'Fourche télescopique inversée, diamètre 45 mm, précontrainte de ressort, détente et étage de compression réglables');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (23, 1, 5, 'guidage de la roue arrière', 'Bras oscillant inférieur en aluminium, Full-floater Pro, jambe de suspension centrale, précontrainte de ressort réglable, niveau de traction et de compression réglable');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (24, 1, 5, 'angle de tête', '66.2°');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (25, 1, 5, 'roues', 'Jantes en aluminium coulé');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (26, 1, 5, 'dimensions jante avant', '3,50 x 17"');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (27, 1, 5, 'dimensions jante arrière', '6,00 x 17"');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (28, 1, 5, 'pneumatique avant', '120/70 ZR17');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (29, 1, 5, 'pneumatique arrière', '190/55 ZR17 (avec roues M : 200/55 ZR17)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (30, 1, 5, 'frein avant', 'Frein à double disque, diamètre 320 mm, 4,5 mm, étrier fixe à 4 pistons (roues M 5 mm)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (31, 1, 5, 'frein arrière', 'Frein monodisque, diamètre 220 mm, étrier flottant 1 piston');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (32, 1, 5, 'abs', 'Race ABS BMW Motorrad semi-intégral, Brake-Slide-Assist');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (33, 1, 5, 'abs pro', 'ABS Pro avec différents réglages en modes Rain, Road Dynamic RACE');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (34, 1, 5, 'débattement avant arrière', '120 mm / 117 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (35, 1, 5, 'chasse', '99,8 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (36, 1, 5, 'empattement', '1 457 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (37, 1, 6, 'hauteur de selle', '824 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (38, 1, 6, 'longueur d''entrejambe', '1 845 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (39, 1, 6, 'capacité utile du réservoir', '16,5 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (40, 1, 6, 'dont réserve', 'env. 4 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (41, 1, 6, 'Longueur', '2 073 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (42, 1, 6, 'Hauteur', '1,205 mm (sans rétroviseurs, pour poids à vide DIN)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (43, 1, 6, 'Largeur', '848 mm (avec rétroviseur)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (44, 1, 6, 'Poids à sec', '175 kg (pack M 173,3 kg) sans batterie');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (45, 1, 6, 'Poids à vide', '197 kg (pack M 193,5 kg)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (46, 1, 6, 'Poids total maximum autorisé', '407 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (47, 1, 6, 'charge utile', '210 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (48, 2, 1, 'type', 'Moteur six cylindres en ligne à quatre temps refroidi par huile/eau avec quatre soupapes par cylindre');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (50, 2, 1, 'Cylindrée', '1 649 cm³');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (51, 2, 1, 'Puissance Nominale', '118 kW à 6 750 tr/min');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (52, 2, 1, 'couple max', '180 Nm à 5 250 tr/min');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (54, 2, 1, 'alimentation', 'Injection électronique indirecte / gestion numérique du moteur : BMS-O avec accélérateur électronique');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (55, 2, 1, 'dépollution', 'Pot catalytique trois voies à régulation lambda, norme antipollution Euro 5');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (56, 2, 2, 'vitesse maximale', 'Supérieure à 200 km/h');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (57, 2, 2, 'consommation pour 100km', '5,9 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (58, 2, 2, 'Emissions de CO2', '137 g/km');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (59, 2, 2, 'type de carburant', 'Super sans plomb (15 % d’éthanol max., E15) / ROZ 95 / 90 AKI');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (60, 2, 3, 'alternateur', 'Alternateur triphasé de 700 W (puissance nominale)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (61, 2, 3, 'batterie', '12 V / 16 Ah, sans entretien');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (62, 2, 4, 'embrayage', 'Multidisque en bain d’huile');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (63, 2, 4, 'boîte de vitesses', '6 rapports à commande par crabots, pignons à denture hélicoïdale');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (64, 2, 4, 'transmission secondaire', 'Cardan');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (65, 2, 5, 'cadre', 'Cadre périmétrique en aluminium, moteur à fonction porteuse');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (66, 2, 5, 'guidage de la roue avant', 'BMW Motorrad Duolever, combiné ressort-amortisseur central');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (67, 2, 5, 'guide de la roue arrière', 'Monobras oscillant en fonte d’aluminium avec Paralever BMW Motorrad ; jambe de suspension centrale');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (68, 2, 5, 'débatement avant arrière', '115 mm / 135 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (69, 2, 5, 'empattement', '1 618 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (70, 2, 5, 'chasse', '106,4 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (71, 2, 5, 'angle de tête', '62,2 °');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (72, 2, 5, 'roues', 'Jante en aluminium coulé');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (73, 2, 5, 'dimensions jante avant', '3,50 x 17"');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (74, 2, 5, 'dimensions jante arrière', '6,00 x 17"');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (75, 2, 5, 'pneumatique avant', '120/70 ZR 17');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (76, 2, 5, 'pneumatique arrière', '190/55 ZR 17');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (77, 2, 5, 'frein avant', 'Frein à double disque, diamètre 320 mm, étrier fixe à 4 pistons');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (78, 2, 5, 'frein arrière', 'Frein monodisque, diamètre 320 mm, étrier flottant à 2 pistons');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (79, 2, 5, 'abs', 'ABS Pro Integral BMW Motorrad (partiellement intégral, optimisé pour les positions inclinées)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (80, 2, 6, 'hauteur de selle', '750 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (81, 2, 6, 'longueur d''entrejambe', '1760 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (82, 2, 6, 'capacité utile du réservoir', 'env. 26,5 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (83, 2, 6, 'dont réserve', 'env. 4 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (84, 2, 6, 'longueur', '2 489 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (85, 2, 6, 'hauteur', '1 490 - 1 580 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (7, 1, 1, 'alimentation', 'Injection électronique, longueur variable du d''aspiration');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (53, 2, 1, 'Rapport volumétrique', '12,2:1');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (49, 2, 1, 'Alésage x course', '72mm x 67,5mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (86, 2, 6, 'largeur', '1 000 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (87, 2, 6, 'poids à vide en ordre de marche', '358 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (88, 2, 6, 'poids total maximum autorisé', '560 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (89, 2, 6, 'charge utile', '202 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (90, 3, 1, 'type', 'Moteur boxer quatre temps deux cylindres, refroidi par air ou huile, avec deux arbres à cames entraînés par chaîne, au-dessus du vilebrequin. ');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (91, 3, 1, 'Alésage x course', '107,1 mm x 100 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (92, 3, 1, 'Cylindrée', '1802 cm³    ');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (93, 3, 1, 'Puissance Nominale', '67 kW (91 ch) à 4750 tr/min');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (94, 3, 1, 'couple max', '158 Nm à 3000 tr/min');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (95, 3, 1, 'Rapport volumétrique', '9,6 : 1');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (96, 3, 1, 'alimentation', 'Injection électronique numérique séquentielle phasée : BMS-O avec accélérateur électronique');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (97, 3, 1, 'dépollution', 'Catalyseur 3 voies à régulation lambda');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (98, 3, 2, 'vitesse maximale', 'Supérieure à 180 km/h');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (99, 3, 2, 'consommation pour 100km', '5,6 l/100km');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (100, 3, 2, 'type de carburant', 'Super sans plomb (15 % d''éthanol max., E15) ROZ 95 90 AKI');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (101, 3, 3, 'alternateur', 'Alternateur à aimant permanent 600 W (puissance nominale)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (102, 3, 3, 'batterie', '12V/26 Ah, sans entretien');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (103, 3, 4, 'embrayage', 'Embrayage monodisque à sec');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (104, 3, 4, 'boîte de vitesses', '6 rapports à commande par crabots, dans un carter de boîte de vitesses séparé');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (105, 3, 4, 'transmission secondaire', 'Cardan');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (106, 3, 5, 'cadre', 'Cadre en acier à double boucle avec entretoises vissées');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (107, 3, 5, 'guide de la roue avant', 'Fourche télescopique');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (108, 3, 5, 'guide de la roue arrière', 'Bras oscillant double en acier avec jambe de force centrale');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (109, 3, 5, 'débatement avant arrière', '120 mm / 90 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (110, 3, 5, 'empattement', '1731 mm    ');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (111, 3, 5, 'chasse', '150 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (112, 3, 5, 'angle de tête', '57,3°');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (113, 3, 5, 'roues', 'Roue à rayons');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (114, 3, 5, 'dimensions jante avant', '3,5" x 19"');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (115, 3, 5, 'dimensions jante arrière', '5,0" x 16"');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (116, 3, 5, 'pneumatique avant', '130/90 B16 ');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (117, 3, 5, 'pneumatique arrière', '180/65 B16');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (118, 3, 5, 'frein avant', 'Frein à double disque, diamètre 300 mm, étrier fixe à quatre pistons');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (119, 3, 5, 'frein arrière', 'Frein monodisque, diamètre 300 mm, étrier fixe à quatre pistons');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (120, 3, 5, 'abs', 'ABS BMW Motorrad (partiellement intégral)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (121, 3, 6, 'hauteur de selle', '710 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (122, 3, 6, 'longueur d''entrejambe', '1655 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (123, 3, 6, 'capacité utile du réservoir', 'env. 16 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (124, 3, 6, 'dont réserve', 'env. 4 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (125, 3, 6, 'longueur', '2440 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (126, 3, 6, 'hauteur', '1342 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (127, 3, 6, 'hauteur (avec bulle)', '964 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (128, 3, 6, 'largeur', '365 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (129, 3, 6, 'poids à vide', '560 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (130, 3, 6, 'poids total', '195 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (131, 4, 1, 'Puissance Nominale', '64 kW (87 ch) à 6 750 tr/min, option réduction de la puissance : 35 kW (48 ch) à 5 500 tr/min');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (132, 4, 1, 'Epuration des gaz d''échappement', 'Catalyseur 3 voies à régulation lambda');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (133, 4, 1, 'Type', 'Bicylindre 4 temps refroidi par eau avec quatre soupapes actionnées par culbuteur par cylindre, deux arbres à cames en tête et lubrification par carter sec');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (134, 4, 1, 'Alésage x course', '86 mm x 77 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (135, 4, 1, 'Cylindrée', '895 cm³');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (136, 4, 1, 'Rapport volumétrique', '13,1 : 1');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (137, 4, 1, 'alimentation', 'Injection électronique indirecte / gestion numérique du moteur : BMS-X avec actionneur de papillon électrique');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (138, 4, 1, 'norme antipollution', 'EU 5');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (139, 4, 1, 'couple max', '91 Nm à 6 750 tr/min, option réduction de la puissance : 70 Nm à 4 500 tr/min');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (140, 4, 2, 'consommation aux 100km selon WMTC', '4,3 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (141, 4, 2, 'type de carburant', 'Super sans plomb (max. 15 % éthanol, E15), 95 ROZ/RON, 90 AKI');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (142, 4, 2, 'vitesse maximale', '190 km/h (option réduction de puissance 35 kW : 161 km/h)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (143, 4, 3, 'Batterie', '12 V / 9 Ah, sans entretien');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (144, 4, 3, 'alternateur', 'Alternateur à aimant permanent 420 W (puissance nominale)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (145, 4, 4, 'embrayage', 'Bain d''huile multidisque (antidribble)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (146, 4, 4, 'boite de vitesses', '6 rapports à commande par crabots, intégrée au carter moteur');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (147, 4, 4, 'transmission secondaire', 'Chaîne X-ring sans fin, amortisseur d’à-coups dans le moyeu de roue arrière');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (148, 4, 5, 'cadre', 'Cadre poutre tubulaire en acier de conception bouclier');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (149, 4, 5, 'guidage de la roue avant', 'Fourche télescopique, diamètre 41 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (150, 4, 5, 'angle de tête de direction', '63°');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (151, 4, 5, 'roues', 'Jantes en aluminium coulé');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (152, 4, 5, 'dimensions jante avant', '2,50 x 19"');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (153, 4, 5, 'dimensions jante arrière', '4,25 x 17"');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (154, 4, 5, 'pneumatique avant', '110/80 R19');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (155, 4, 5, 'pneumatique arrière', '150/70 R17');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (156, 4, 5, 'Frein avant', 'Frein à double disque flottant, diamètre 305 mm, étrier flottant à double piston');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (157, 4, 5, 'frein arrière', 'Monodisque, diamètre 265 mm, étrier flottant à 1 piston');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (158, 4, 5, 'abs', 'BMW Motorrad ABS');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (159, 4, 5, 'chasse', '106,1 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (160, 4, 5, 'empattement', '1 556 mm');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (161, 4, 5, 'guidage de la roue arrière', 'Bras oscillant double en aluminium, jambe de suspension centrale, amortissement en détente réglable');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (162, 4, 5, 'débattement avant arrière', '170 mm / 170 mm (équipement optionnel : surbaissement 150 mm / 150 mm)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (163, 4, 6, 'hauteur de selle', '815 mm (option surbaissement : 760 mm, option selle extra-basse : 780 mm, accessoire selle basse : 790 mm, option selle confort : 830 mm, accessoire selle rallye : 845 mm)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (164, 4, 6, 'longueur d''entrejambe', '1 830 mm (option surbaissement : 1 730 mm ; option selle extra-basse : 1 770 mm ; accessoire selle basse : 1 790 mm ; option selle confort : 1 870 mm, accessoire selle rallye : 1 890 mm)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (165, 4, 6, 'capacité utile du réservoir', '15 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (166, 4, 6, 'dont réserve', 'env. 4 l');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (167, 4, 6, 'hauteur', '1 225 mm (avec bulle, poids à vide DIN)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (168, 4, 6, 'poids à vide en ordre de marche', '227 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (169, 4, 6, 'poids total maximum autorisé', '440 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (170, 4, 6, 'charge utile', '213 kg');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (171, 4, 6, 'longueur', '2 296 mm (avec cadre de plaque d''immatriculation)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (172, 4, 6, 'largeur', '910 mm (sans élément rapporté)');
INSERT INTO "BMWMottorad".t_e_caracteristique_car VALUES (1, 1, 1, 'Puissance Nominale', '154 kW (210 ch) à 13.750 tr/min');


--
-- Data for Name: t_e_categorieequipement_cte; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (1, NULL, 'Casquettes et Bonnets');
INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (2, NULL, 'Equipements fonctionnels et Protections');
INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (3, 1, 'T-shirt et Tops');
INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (4, 3, 'Sweatshirts et Hoodies');
INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (5, 3, 'Vestes');
INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (6, 2, 'Bottes et Sneakers');
INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (7, 2, 'Casques');
INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (8, NULL, 'Combinaisons');
INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (9, 2, 'Pantalons et Jeans');
INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (10, 2, 'Sacs et Accessoires');
INSERT INTO "BMWMottorad".t_e_categorieequipement_cte VALUES (11, 10, 'Gants');


--
-- Data for Name: t_e_client_clt; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_client_clt VALUES (75, 81, 'M', 'Cussonait', 'Simon', '1969-12-12', 'levraisimoncussonait@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (78, 84, 'M', 'commande', 'sans', '2004-06-23', 'sanscommande@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (79, 85, 'M', 'commande', 'avec', '2004-06-23', 'avecommande@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (67, 73, 'M', 'Turconito', 'Arturo', '1999-06-13', 'arturo@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (68, 74, 'M', 'Commerce', 'Commerce', '1911-10-13', 'commerce@bmw.fr');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (72, 78, 'M', 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (81, 87, 'M', 'avec', 'avec', '2004-06-23', 'avec@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (65, 71, 'M', 'Kompaniets', 'Anna', '2004-01-23', 'anna.kompaniets@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (52, 57, 'M', 'Colin', 'Pascal', '1995-02-21', 'pascal.colin@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (53, 58, 'M', 'Shoah', 'Simon', '2004-06-23', 'simon@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (55, 61, 'M', 'GOY', 'Simon', '2004-02-03', 'simon@bmw.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (56, 62, 'M', 'GOY', 'Simon', '2004-02-03', 'sg.bonneville@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (61, 67, 'Mme', 'Carter', 'Helène', '1973-06-05', 'helene.carter@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (69, 75, 'M', 'CPT', 'Réparez le site plz', '1999-11-11', 'css_404_not_found@iutannecy-deptinfo.fr');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (73, 79, 'M', 'DPO', 'DPO', '2001-06-14', 'dpo@bmwmottorad.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (76, 82, 'x', 'x', 'x', '2004-06-23', 'F4XpG3ZPQKwkR12K00CoOHcVQdSNqrp9Yqr7XsOVoscP9f2vbz@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (47, 47, 'x', 'x', 'x', '1985-01-05', 'MjqSfx1YulXwVsPEpMoesUeOkSitHb4HbgSTBVcH8QB4LAHDIY@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (70, 76, 'x', 'x', 'x', '2004-04-23', 'mJjJZlrpOdHA28OJYB3DM5BI4D16CSiY2AuhAuMJaYutrMpViv@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (27, 27, 'x', 'x', 'x', '1961-12-29', 'VUA3ux5XIMZdLvUEE0zy8WAcHxGRpYQhgGe9RotguMF9pIVCFN@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (30, 30, 'x', 'x', 'x', '1990-05-17', '3TrrsAUNDSiuV5RqYqD1VocpBKAcFtGQ9OFOG8R91Ad3NrA86J@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (31, 31, 'x', 'x', 'x', '1967-12-17', 'Ko4xAL1XtaqkY1aipsPTcqPPVYVL5vaakRLHRBCRHK8968zKuf@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (39, 39, 'x', 'x', 'x', '2003-07-27', '6bLZdMHzacwVZ0mHusdYX0ff1XgNlqLvy7E4e6bqevUAGg3vz0@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (40, 40, 'x', 'x', 'x', '2004-07-14', 'DKGSLZk63A359E6RieIZy3C31bKw39NvyqGAJXT01DURegvrNo@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (42, 42, 'x', 'x', 'x', '1986-04-17', 'iUothShkkv1sUJp0weP8zh0QCnZdSFTaDy2n1CDdITZbUudIpX@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (43, 43, 'x', 'x', 'x', '2002-02-08', 'HR7ove99OTJxXU8uOtH42YYM6suAgwRd9oFKq8nNmxa0v6aHUH@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (44, 44, 'x', 'x', 'x', '1980-06-20', 'JgxWhcG9kXRpzeHgFmeI0ikDPYsp3SUe1Q7hhCxZangCUfzzSR@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (46, 46, 'x', 'x', 'x', '1994-05-25', '7UYRpyDn1xtXB9exrp4Umff3Fq6FsaSGREJKDlouQ1W9EOImkl@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (50, 50, 'x', 'x', 'x', '1980-09-17', '5jluGEd6KPpRrhgjJ4IO4kPODfuorOCW8D28xKdhjzZMhkQjcr@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (48, 48, 'x', 'x', 'x', '1963-06-12', 'MPSvvv7lVJ8xdlnV6QvZHqThY3AFSeaAglXWGEuOR9r1MP3vJq@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (49, 49, 'x', 'x', 'x', '1963-04-10', 'Bq7DWIJmLNMHj8TWgiw5mbgjJ2UxZAl5ObDbEYIjNU8myNfTTd@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (77, 83, 'x', 'x', 'x', '2004-06-23', 'TiSycL3SxW6dpOqrfTb2NJbXi2PNEjWpjS3YO9U6u0mhySSHbq@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (1, 1, 'x', 'x', 'x', '1963-12-20', 'MTCI5r8I9d8yzSjmpO7MTP62e7ZFy3wgrNe607FFsOZo49ruDU@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (3, 3, 'x', 'x', 'x', '1984-10-06', '1jvukk0GZetW7roJl6g9pmOLW4ovBY3dehkCN6gw6xMfreM08G@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (6, 6, 'x', 'x', 'x', '1964-09-16', 'DNGxGKZBfzxW91xn2CPiAN1ZUzzqSjqxGiuw7CiqI8dWIf1SKU@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (8, 8, 'x', 'x', 'x', '1979-01-04', '0IfzmhKnwKKC8PAwxZ14PpAdQrrMS8IzKevHwz17r3cJbk7U6j@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (9, 9, 'x', 'x', 'x', '1995-01-05', 'oilzOE5ab2UZ1GhCWF9mHNovbBT7myoWy3meoEEo1j6OYBoknD@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (12, 12, 'x', 'x', 'x', '2003-05-07', 'ySVWhyWzX9Mn5nda8CWdtaIgxCGHg5dZGsWSKOCyyERMEfXnlD@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (2, 2, 'x', 'x', 'x', '1999-01-09', 'LrRYXZ2w9SKGtoWl2GN0wRgfpIVaX9qGSicwWDMdswCjFUyF2f@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (4, 4, 'x', 'x', 'x', '1976-06-11', '0eFF1JEDQKyvcVyAvpPFMwipbQ17fw36IxhKgfev1jpDhb4LOc@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (5, 5, 'x', 'x', 'x', '1982-04-20', '4fvxlo1e3BFL2IM3sQh7QWMpBKqreRA7I9cWRF17tJwZZNA57T@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (7, 7, 'x', 'x', 'x', '2000-11-23', 'LC5JhLaAgHzS1orLYhxjlGKvmce0CdbApa1OtzD3hIlIwiwnXH@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (10, 10, 'x', 'x', 'x', '1990-03-04', '5Rq9GPz6DG8W1bd6wxauV8kJIFrQHjdJbPR3uEzRNehjYjomUM@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (11, 11, 'x', 'x', 'x', '1973-01-01', 'ir1wXKVNQZvtt31u5tmxZCfW77oCvFjCeyjad4TK0w05sTwxrx@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (13, 13, 'x', 'x', 'x', '1966-11-22', 'Y0yUOVsPleIaXEbVsmJhIWdqB0fdLnFoJuQSUhsoEXhQoxCURu@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (14, 14, 'x', 'x', 'x', '1962-03-06', '1Bhy5ut0GKhFu5rGc7G37XSPHAYVNErNUft5EC1elcn5aLTTdt@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (16, 16, 'x', 'x', 'x', '1989-04-20', 'XYTNGijolF3qkKtOqYxxN0xJ4DCL8aRuhaN20L5uZB4yuvkmdm@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (17, 17, 'x', 'x', 'x', '1986-09-14', 'RpqoBIPMBOH6C8obgmIYWTacQ8b1auDrAsgBfsb5NlHfXatBHr@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (24, 24, 'x', 'x', 'x', '1998-03-02', '8m30mLGRorVc2wEcpbhVfsRv0L0hxGZS7LJBaCO538872bV682@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (26, 26, 'x', 'x', 'x', '1979-10-28', 'D8Wku0Lr7LA1ygUmVNMO3ZenVAPypHKQUyWBMtYVOqaQhIEyfb@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (28, 28, 'x', 'x', 'x', '1981-05-14', 'z9SLeUHzWs6Aqzem7Wb9REVgiDTTqzdT1ZTaXIg8tUTBPAgqkP@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (29, 29, 'x', 'x', 'x', '1969-10-21', 'uyZkg0SxVhqBp9R43WuMasNpuZG3mQ1PZ6TzDE7YpkxjfeCNbq@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (32, 32, 'x', 'x', 'x', '1976-04-09', 'd1LXWLoKF3HaGV0guzZaomqqKQifK93dmVd9j81KcCiNH9lIfp@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (33, 33, 'x', 'x', 'x', '2001-12-27', 'n2Y7KtKfr5jHOPr1HtaOS9S126w9RFJN8NClaraaUNCuhbnivn@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (34, 34, 'x', 'x', 'x', '1973-06-18', '2qdVu6X84Y3onyA89xhhUl9MT7jDQzhiBYdBJlIZCUKw3I2P4O@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (35, 35, 'x', 'x', 'x', '1986-01-02', 'vPcaDHiETcUfespuEvrN1PdcbcY0Zcr7o6wceU6yMmxIbaU3Ry@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (36, 36, 'x', 'x', 'x', '1993-01-23', 'CkRppa7v6A9AGUrHha4JXIpqtOBWzXIbklwgGodLCyV1UZPnlL@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (37, 37, 'x', 'x', 'x', '1990-04-03', 'ZINRboHUlvEqNZCxqmdcwUqQfeF2uSLrRTAe7tVBXmMsRVZPVi@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (38, 38, 'x', 'x', 'x', '1997-05-30', 'bG6luk7Q9UVb5yGaGxWK4fopmDjxwwP0SAyzkxdBbvWUJ9hTZt@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (41, 41, 'x', 'x', 'x', '1986-04-18', 'uBdXpIkstULnPtJb09CNUNZzhOD1gepibXMTeIxXfAzE10uQb4@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (45, 45, 'x', 'x', 'x', '1963-07-15', 'CsJt7cCT4Qi6JF9mxIVEWTLHhHQF0jP9hAOqn9bwSCdS4BzPrD@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (62, 68, 'x', 'x', 'x', '1900-01-01', 'zqFDwbDQrEYqFmi6sz5XzwjmULS2iQatqZWXUa2u5xNscKqi5n@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (54, 60, 'x', 'x', 'x', '2004-06-23', 'GMLKQREfzxLCpZt7SMMSxmHAmFMTDt3XkW6aLqKG9umwvoY1Rh@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (66, 72, 'x', 'x', 'x', '1964-12-04', 'r4KLQNpaIwYwqedAJTj4oSnNV3Lx4rKqXCm4XuuHsHeU4z00lB@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (63, 69, 'x', 'x', 'x', '1978-12-11', 'mDGT7pIzctRdV4PVYKNFNnzg9mlU4rIxTAm9ThfwPzIFhCbOlC@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (64, 70, 'x', 'x', 'x', '1945-05-12', 'Vqg3S10KjklwyuNIR5H3PHSsZRoGcB3lBTHIXI2jVFewiWrftM@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (15, 15, 'x', 'x', 'x', '1999-01-06', 'XKZ6x1my3DiTsbxA7LuF2SxgC0pIR8eyHYVaZebmKjySs86CEg@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (18, 18, 'x', 'x', 'x', '2000-02-01', '4vbcDCxr4C0AyxoU8lac6bz6EWxMv0ukmVgg0JlnqJZljM1816@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (19, 19, 'x', 'x', 'x', '1971-09-08', 'wOkjiNWQjJJusXw5izkJfNas4CRZRAMjmByzEALHKRRlCS0F9d@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (20, 20, 'x', 'x', 'x', '1991-10-29', '2wkdkPIP2QtAr22MYck3uHG70zu9itCL9rxHQ0iy2BcwJBqEdx@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (21, 21, 'x', 'x', 'x', '1994-07-11', 'VxiyD9KFS4wcjlLWaP3Qqw2PST7892XR24DaOii9Wyehr9zHIs@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (22, 22, 'x', 'x', 'x', '1984-11-15', 'zQmB7fOwZmPPcmxi9tOinvetbznMwClgdPFCBlklJlXh0w93lJ@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (23, 23, 'x', 'x', 'x', '1967-09-14', 'VqDAXVCaFiylFxiXxqGwa8lkIaw8jm6HgqJEwBCFaijB0ZXPO6@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (25, 25, 'x', 'x', 'x', '1967-12-18', 'fLeZCjjNs0etpFr9xx8fGPOIwCuQY1HhSx20NehhCEKT5VmpoX@xx.xx');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (90, 90, 'M', 'Island', 'Epstein', '2003-06-04', 'epstein@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (91, 91, 'M', 'Cussonait', 'Simon', '2004-06-23', 'simon.cussonait@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (92, 92, 'M', 'Hawking', 'Stephen', '1974-06-06', 'stephenh@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (93, 93, 'M', 'Paddle', 'Homme', '1987-06-04', 'paddle@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (94, 94, 'Mme', 'coline', 'pascaline', '1991-06-20', 'pascaline@coline.fr');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (95, 95, 'M', 'Milftari', 'Dylan', '1997-06-19', 'dydylan@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (96, 96, 'M', 'Nomtest', 'Prenomtest', '2004-06-23', 'prenom.nom@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (97, 97, 'M', 'ZAZA', 'ZOUZOU', '2004-06-23', 'zouzou@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (98, 98, 'M', 'Obmana', 'Barack', '2004-06-23', 'barack@maisonblanche.fr');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (200, 200, 'M', 'BarbaFamille', 'Barbapapa', '1999-12-23', 'barbapapa@gmail.com');
INSERT INTO "BMWMottorad".t_e_client_clt VALUES (201, 201, 'M', 'PasGay', 'Simon', '2000-11-26', 'simon.pasgay@gmail.com');


--
-- Data for Name: t_e_collection_cln; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_collection_cln VALUES (1, 'Casual Wear');
INSERT INTO "BMWMottorad".t_e_collection_cln VALUES (2, 'Riders Gear');


--
-- Data for Name: t_e_coloris_cls; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (1, 'Noir');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (2, 'Rouge');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (3, 'Camel');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (4, 'Nachtblau');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (5, 'Gris');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (6, 'Gris/bleu');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (7, 'Jaune');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (8, 'Bleu foncé');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (9, 'Khaki');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (10, 'Bleu');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (11, 'Nachtblau/Rot');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (12, 'Jaune néon');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (13, 'Blanc');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (14, 'Olive');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (15, 'Neon Red');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (16, 'Thar');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (17, 'Catamarca');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (18, 'Grey matt');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (19, 'Light white');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (20, 'Lut');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (21, 'Neon orange matt');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (22, 'Night black');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (23, 'Anvil');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (24, 'Black matt');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (25, 'Blue matt');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (27, 'Heritage');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (26, 'Gunmetal');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (28, 'Mallet');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (29, 'Rosslyn');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (30, 'Brun');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (31, 'Orange');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (32, 'Anthracite');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (33, 'Com');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (34, 'Rock');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (35, 'Urban');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (36, 'Neon');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (37, 'Specter');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (38, 'Machine');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (39, 'Thunder');
INSERT INTO "BMWMottorad".t_e_coloris_cls VALUES (0, 'Rien, test');


--
-- Data for Name: t_e_commande_cmd; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (1, 5, '2022-01-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (4, 20, '2022-02-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (5, 24, '2022-03-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (6, 25, '2022-04-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (7, 8, '2022-05-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (8, 49, '2022-06-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (9, 48, '2022-07-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (10, 25, '2022-08-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (11, 47, '2022-09-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (12, 16, '2022-10-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (13, 42, '2022-11-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (14, 2, '2022-12-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (15, 11, '2022-03-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (16, 25, '2022-04-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (17, 25, '2022-11-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (18, 23, '2022-03-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (19, 39, '2022-05-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (20, 16, '2022-06-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (21, 23, '2022-02-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (22, 21, '2022-12-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (23, 10, '2022-10-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (24, 18, '2022-08-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (25, 40, '2022-09-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (26, 20, '2022-07-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (27, 48, '2022-10-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (28, 25, '2022-12-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (29, 49, '2022-01-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (30, 39, '2022-02-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (31, 18, '2023-03-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (32, 26, '2023-04-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (33, 14, '2023-05-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (34, 15, '2023-06-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (35, 21, '2023-07-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (36, 9, '2023-01-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (37, 30, '2023-02-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (38, 17, '2023-03-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (39, 1, '2023-04-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (40, 21, '2023-05-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (41, 24, '2023-06-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (42, 2, '2023-07-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (43, 46, '2023-08-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (44, 30, '2023-09-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (45, 14, '2023-10-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (46, 19, '2023-11-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (47, 46, '2023-12-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (48, 28, '2023-12-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (49, 20, '2023-11-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (50, 18, '2023-03-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (51, 49, '2023-04-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (52, 32, '2023-05-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (53, 28, '2023-06-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (54, 7, '2023-08-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (55, 41, '2023-09-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (56, 8, '2023-11-04', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (57, 18, '2023-12-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (58, 21, '2023-12-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (59, 3, '2023-07-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (60, 11, '2023-08-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (61, 30, '2023-09-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (62, 14, '2023-04-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (63, 25, '2023-05-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (64, 17, '2023-07-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (65, 7, '2023-07-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (66, 13, '2023-06-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (67, 20, '2023-03-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (68, 13, '2023-04-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (69, 35, '2023-09-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (70, 19, '2023-01-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (71, 45, '2023-10-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (72, 3, '2023-01-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (73, 8, '2023-02-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (74, 14, '2023-03-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (75, 40, '2023-04-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (76, 44, '2023-05-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (77, 39, '2023-06-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (78, 13, '2023-08-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (79, 39, '2023-09-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (80, 19, '2023-10-22', 1);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (96, 62, '2023-02-02', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (134, 62, '2023-12-18', 2);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (135, 72, '2023-12-18', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (136, 72, '2023-12-18', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (137, 72, '2023-12-19', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (138, 79, '2023-12-19', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (139, 81, '2023-12-19', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (2, 46, '2022-01-22', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (3, 49, '2022-02-22', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (129, 70, '2023-12-13', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (130, 72, '2023-12-15', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (132, 72, '2023-12-17', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (133, 72, '2023-12-17', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (131, 62, '2023-12-16', 2);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (200, 91, '2024-01-14', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (400, 201, '2024-01-15', 0);
INSERT INTO "BMWMottorad".t_e_commande_cmd VALUES (401, 72, '2024-02-03', 0);


--
-- Data for Name: t_e_concessionnaire_con; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_concessionnaire_con VALUES (1, 'dydy automobiles', 'dydy.motorad@gmail.com', 'dydymotorad.fr', '0245786345', '161 Rue de la chaudière 74290 Faverges');
INSERT INTO "BMWMottorad".t_e_concessionnaire_con VALUES (2, 'couturier motorad', 'couturier.motorad@gmail.com', 'couturiermotorad.fr', '0278848498', '25 Rue de la paix 75100 Paris');
INSERT INTO "BMWMottorad".t_e_concessionnaire_con VALUES (3, 'moto pas chere', 'motopaschere@gmail.com', 'motopaschere.fr', '0285326515', '40 Boulevard de la pomme 68900 Nice');
INSERT INTO "BMWMottorad".t_e_concessionnaire_con VALUES (4, 'très bon concessionnaire', 'bonconcessionnaire@contact.fr', 'bonconce.fr', '0278965445', '87 Chemin du cussonant 69700 Toulouse');
INSERT INTO "BMWMottorad".t_e_concessionnaire_con VALUES (5, 'BMW Motorad ANNECY', 'BMWMOTORADANNECY@contact.fr', 'motoradannecy.fr', '0232320010', '42 Boulevard de la chicane 43090 Poitou');


--
-- Data for Name: t_r_motoconfigurable_mcf; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (1, 1);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (2, 3);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (3, 2);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (4, 4);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (5, 4);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (6, 2);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (7, 3);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (8, 2);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (9, 3);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (10, 1);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (11, 4);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (12, 1);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (13, 4);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (14, 3);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (15, 3);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (16, 2);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (17, 4);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (18, 1);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (19, 3);
INSERT INTO "BMWMottorad".t_r_motoconfigurable_mcf VALUES (20, 2);


--
-- Data for Name: t_e_offre_ofr; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_offre_ofr VALUES (1, 15, 1, false, 'Sans Financement');
INSERT INTO "BMWMottorad".t_e_offre_ofr VALUES (2, 3, 1, false, 'Sans Financement');
INSERT INTO "BMWMottorad".t_e_offre_ofr VALUES (3, 9, 5, true, 'Financement Particulier');
INSERT INTO "BMWMottorad".t_e_offre_ofr VALUES (4, 13, 4, true, 'Financement Professionnel');
INSERT INTO "BMWMottorad".t_e_offre_ofr VALUES (5, 19, 5, false, 'Financement Professionnel');
INSERT INTO "BMWMottorad".t_e_offre_ofr VALUES (6, 1, 2, false, 'Sans Financement');


--
-- Data for Name: t_e_contactinfo_ctf; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (1, 4, 'Mortello', 'Joris', '1987-04-06', 'joris.mortello@gmail.com', '0645785433');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (2, 3, 'Thomas', 'Matthéo', '1999-11-12', 'mattheo.thomas@gmail.com', '0712457888');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (3, 6, 'Delabrouille', 'Luc', '2002-11-16', 'luc.delabrouille@gmail.com', '0645788854');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (4, 2, 'Ruiz', 'Manon', '1987-02-24', 'manon.ruiz@gmail.com', '0612330410');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (5, 1, 'Holmes', 'Sherlock', '1986-01-12', 'sher.holmes@gmail.com', '0645780030');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (6, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (7, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (9, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (10, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (11, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (12, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (13, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (14, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (15, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (16, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (17, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (18, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (19, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (20, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (21, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (22, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (23, NULL, 'tutru', 'tutur', '2004-06-23', 'arthur@gmail.com', '0897574823');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (24, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (25, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (26, NULL, 'Turconi', 'Arthur', '1999-12-08', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (27, NULL, 'Turconi', 'Arthur', '1999-12-08', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (28, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (29, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (30, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (31, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (32, NULL, 'Turconi', 'Arthur', '1999-02-02', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (33, NULL, 'Turconi', 'Arthur', '1999-02-02', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (34, NULL, 'Turconi', 'Arthur', '1999-02-02', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (35, NULL, 'Turconi', 'Arthur', '1999-02-02', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (36, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (37, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (38, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (39, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (40, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (41, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (42, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (43, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (44, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (45, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (46, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (47, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (48, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (49, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (50, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (51, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur.turconi@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (52, NULL, 'tutur', 'Arthur', '2004-06-23', 'arthur@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (53, NULL, 'tutur', 'Arthur', '2004-06-23', 'arthur@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (54, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (55, NULL, 'Turconi', 'Arthur', '2004-06-23', 'arthur@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (56, NULL, 'AAAAAAAAAA', 'AAAAAAAAAA', '1999-11-11', 'css_404_not_found@iutannecy-deptinfo.fr', '0404040404');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (57, NULL, 'AAAAAAAAAA', 'AAAAAAAAAA', '1999-11-11', 'css_404_not_found@iutannecy-deptinfo.fr', '0404040404');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (58, NULL, 'Cussonait', 'Arthur', '2004-06-23', 'arthur@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (59, NULL, 'Cussonait', 'Arthur', '2004-06-23', 'arthur@gmail.com', '0783231325');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (60, NULL, 'Laval', 'Emilie', '1999-12-07', 'emilie.laval@gmail.com', '0649190054');
INSERT INTO "BMWMottorad".t_e_contactinfo_ctf VALUES (61, NULL, 'Laval', 'Emilie', '1999-12-07', 'emilie.laval@gmail.com', '0649190054');


--
-- Data for Name: t_e_equipement_equ; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (9, 2, 'pantalon xride gore-tex', 'Le pantalon XRide GORE-TEX sait convaincre par des caractéristiques globales de sécurité et un excellent confort. Grâce à des inserts en cuir spécialement disposés et à l’utilisation de matériaux élastiques aux genoux et à la ceinture, le pantalon offre une grande liberté de mouvement ainsi qu’un parfait maintien. Un détail haut de gamme : inserts en cuir de vachette sur les zones exposées en cas de chute.', 'f', 710, 0, true, 'Adventure', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (1, 7, 'casque GS Pure', 'Le casque Enduro GS Pure est le compagnon idéal pour les aventures sur la route ou en tout-terrain. Ce casque peut se transformer rapidement et en toute simplicité en versions MX (cross), naked ou casque Enduro Touring avec visière. Le nouveau pare-soleil avec mécanisme push/pull se commande facilement, même avec des gants.', 'uni', 590, 5, true, 'Adventure', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (13, 6, 'bottes venturegrip gore-tex', 'Adaptées à un usage quotidien, les bottes VentureGrip GORE-TEX robustes conviennent aussi bien au Touring qu’à l’enduro. Conçues en cuir de vachette pleine fleur, les bottes robustes offrent une protection élevée et se distinguent par un confort hors norme. Grâce à la membrane GORE-TEX, elles sont étanches, coupe-vent et très respirantes.', 'uni', 360, 0, false, 'Adventure', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (2, 7, 'casque Bowler', 'Le casque Bowler s’adresse aux motards branchés qui apprécient le design classique et chic. Le look rétro se reflète également dans des détails intéressants, tels que les applications en cuir ou la doublure frappée du logo BMW. La forme ajustée s’adapte de manière optimale à chaque taille. Une large gamme d’accessoires complète le catalogue.', 'uni', 463, 5, false, 'Adventure', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (5, 5, 'veste xride gore-tex', 'Que ce soit pour profiter d’une conduite sportive ou pour partir à l’aventure sur de longues distances : le blouson XRide GORE-TEX sait convaincre par des caractéristiques globales de sécurité et un grand confort. Grâce à sa matière extérieure élastique, aux inserts en cuir disposés sous forme de plis ergonomiques et aux bandes élastiques, il offre une grande liberté de mouvement et un grand confort en toutes circonstances.', 'f', 910, 0, true, 'Sport', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (14, 6, 'bottes gs competition', 'Une capacité tout-terrain sans compromis : Les bottes GS Competition ont tout ce qu’il faut pour tenir en dehors des sentiers battus. La solide conception de type cadre en polyuréthane, la plaque protège-tibia ajustable et les grands éléments plastiques offrent une protection optimale dans des conditions de conduite extrêmes.', 'h', 400, 0, true, 'Adventure', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (6, 5, 'blouson summerxcursion', 'Le blouson SummerXcursion avec une coupe sportive est le compagnon idéal pour les sorties estivales. La matière extérieure est en polyamide résistant à l’abrasion et assure en permanence une ventilation optimale. Ce blouson à la mode peut ainsi être porté sans problème même lorsqu’il fait très chaud.', 'h', 400, 0, false, 'Roadster', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (8, 2, 'pantalon london', 'Conçu dans un look moderne à 5 poches, le pantalon London fait bonne figure, même en dehors du monde de la moto. Les protecteurs NP Flex 3D aux genoux offrent d’excellentes capacités d’amortissement des chocs et n’altèrent en rien le confort du pantalon.', 'h', 260, 0, false, 'Urban Mobility', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (3, 7, 'Casque SAO PAULO', 'Très tendance, confortable et en toute sécurité à travers la métropole – c’est ce que représente le casque Sao Paulo à visière longue et pare-soleil intégré. Les éléments de ventilation refermables sur le dessus de la tête et le spoiler empêchent l’accumulation de chaleur. Ils sont extrêmement aérodynamiques et conçus pour être efficaces. Pratique : le rembourrage intérieur amovible et lavable.', 'uni', 100, 5, false, 'Urban Mobility', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (7, 2, 'jean roadcrafted', 'Grâce à ses protecteurs discrets, le jean RoadCrafted pour femme en denim élastique et résistant à l’abrasion conjugue une sécurité et fonctionnalité avec un look classique.', 'f', 393, 0, false, 'Heritage', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (16, 11, 'masque enduro gs pro', 'Parfaite visibilité sur tous les terrains : le masque Enduro GS Pro est parfaitement équipé pour le tout-terrain avec son verre double ventilé. Un revêtement spécial protège le verre contre la buée et les rayures. Particulièrement pratique pour les personnes qui portent des lunettes : le cadre over-the-glasses est facile à porter au-dessus de lunettes normales.', 'uni', 110, 0, false, 'Adventure', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (12, 11, 'sac à dos black collection', 'Le sac à dos Black Collection, grand modèle, a la taille idéale pour les grandes balades et les voyages avec un peu plus de bagages. Avec le compartiment principal imperméable et son compartiment pour ordinateur portable intégré (jusqu’à 15"), vous ne craignez pas les averses. Il est possible d’étendre le volume total de 25 à 30 litres.', 'uni', 191, 0, false, 'Adventure', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (28, 7, 'Casque Xomo Carbon', 'Le casque Xomo Carbon est la preuve qu’une excellente protection ne doit pas être inconfortable. Le casque intégral sport avec coque en matériau composite à base de carbone offre de nombreuses options confortables comme des coussinets pour les joues à conception tridimensionnelle, le système Easy Fit pour porteur de lunettes, un système de visière ergonomique avec fonction Soft Close et un rabat amovible sur le menton.', 'uni', 80000000000000, 5, true, 'Tour', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (17, 11, 'dragonne tour de cou motorsport', 'Dragonne tour de cou bicolore avec logo BMW Motorrad et porte-clés.', 'uni', 20, 0, true, 'Sport', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (22, 8, 'combinaison m prorace comp', 'La combinaison M ProRace Comp combine des exigences sportives élevées avec un pack sécurité complet. Les protecteurs aux épaules, aux coudes, aux hanches et aux genoux assurent la sécurité. Alors qu’une bosse dorsale optimise l’aérodynamisme, les couleurs M Motorsport montrent ce que cette combinaison qui ne passe pas inaperçue représente : des performances de pointe.', 'h', 1710, 0, false, 'Sport', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (26, 10, 'gants gs puna gore-tex', 'Parfaits pour les virées prolongées : Les gants Enduro GS Puna GORE-TEX offrent une protection optimale contre le vent et les intempéries. La membrane respirante GORE-TEX X-TRAFIT™ empêche l’eau et le froid de pénétrer. Les doublures en cuir, le SuperFabric® très résistant à l’abrasion et une protection souple des articulations des doigts viennent compléter ce robuste ensemble.', 'f', 140, 0, true, 'Adventure', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (10, 11, 'sac à dos motorsport', 'Sac à dos pratique avec fermeture par enroulement au look BMW Motorsport.', 'uni', 70, 0, false, 'Adventure', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (20, 9, 'veste de protection', 'Grâce aux protections NP3 Flex au niveau de la poitrine, des bras et du dos, la veste de protection réduit les risques de blessure. La veste s’adapte parfaitement sous l’effet de la chaleur du corps Des matériaux respirants et particulièrement légers garantissent également un grand confort. Pratique : La veste est lavable en machine grâce aux protecteurs amovibles.', 'uni', 230, 0, false, 'Sport', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (21, 9, 'ceinture lombaire pro', 'Avec sa ceinture de protection lombaire avec fonction NP3 Flex à renfort souple, la ceinture lombaire Pro offre une bonne protection du bas du dos. Le système de ceinture en caoutchouc réglable en continu garantit un excellent soutien. En combinaison avec le réglage de largeur en continu, la maille intégrée et proche du corps offre un confort optimal.', 'uni', 90, 0, false, 'Adventure', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (23, 8, 'skin function rr', 'Sous-combinaison une pièce pour une parfaite thermorégulation.', 'h', 110, 0, false, 'Sport', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (18, 11, 'porte-clés gs logo', 'Porte-clés avec impression à plat sur la face avant.', 'uni', 20, 0, true, 'Adventure', 1);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (11, 11, 'sac pour casque bmw motorrad', 'Le sac pour casque RidersTrunk offre suffisamment de place pour vos objets quotidiens. En plus du compartiment principal avec fermeture zippée, il possède un compartiment refermable pour ordinateur portable et deux poches latérales avec bouton-pression. La poignée et la bandoulière permettent de porter facilement ce sac, le compagnon idéal de votre quotidien sur deux roues.', 'uni', 180, 0, true, 'Adventure', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (19, 9, 'protection dosale à bretelles', 'La protection dorsale à bretelles réduit les risques de blessure, grâce à sa protection à fonction NP3 Flex. La protection à bretelles est particulièrement légère ; elle se ressent à peine lors du port. Les sangles d’épaule légèrement rembourrées et parfaitement ergonomiques assurent également un grand confort, de même que la ceinture lombaire intégrée et réglable en largeur.', 'uni', 190, 0, false, 'Adventure', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (15, 6, 'sneakers seoul gore-tex', 'Les sneakers Séoul GORE-TEX ne séduisent pas seulement par leur remarquable esthétique. La membrane GORE-TEX offre une protection contre le vent et l’eau, tandis que la semelle résistante à l’huile et au carburant ainsi que la protection intégrée des talons et des articulations assurent un véritable gain de sécurité. La fermeture éclair dissimulée sur la partie interne garantit une mise en place et un retrait rapides.', 'uni', 250, 0, false, 'Urban Mobility', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (24, 8, 'blouson & pantalon hotlap', 'Conçu en cuir de vachette Nappa extrêmement résistant aux chutes et à l’usure, le blouson Hotlap allie confort et sécurité. Grâce aux nombreux éléments élastiques et aux inserts extensibles en cuir au niveau des épaules et des manches, et malgré la présence de protecteurs, le blouson offre une liberté de mouvement optimale, quelle que soit la position d’assise.', 'h', 1110, 0, false, 'Sport', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (25, 10, 'gants tenda 2in1 gore-tex', 'Fonction 2 en 1 pour plus de confort : les gants sport Tenda 2in1 GORE-TEX, avec système à 2 chambres, cachent bien leur jeu. Alors que la première chambre en cuir kangourou non doublée procure une excellente prise en main du guidon avec la paume de la main, la deuxième, imperméable, car dotée d’une membrane respirante GORE-TEX, offre une protection parfaite contre les aléas de la météo.', 'uni', 200, 0, true, 'Tour', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (27, 10, 'gants reschen gore-tex', 'Parfaits pour les virées prolongées : Les gants Enduro Reschen GORE-TEX offrent une protection optimale contre le vent et les intempéries. La membrane respirante GORE-TEX X-TRAFIT™ empêche l’eau et le froid de pénétrer. Les doublures en cuir, le SuperFabric® très résistant à l’abrasion et une protection souple des articulations des doigts viennent compléter ce robuste ensemble.', 'h', 140, 0, false, 'Adventure', 2);
INSERT INTO "BMWMottorad".t_e_equipement_equ VALUES (4, 5, 'blouson schwabing', 'Le blouson Schwabing au look Heritage fait revivre un classique au design revisité. Les doubles rayures traditionnelles sur les manches ajoutent une touche esthétique particulièrement marquante. Sous le cuir de vachette de haute qualité, les protecteurs NP Flex aux épaules et aux coudes assurent la sécurité, tandis que deux poches extérieures et trois poches intérieures offrent des possibilités de rangement.', 'h', 570, 0, true, 'Adventure', 2);


--
-- Data for Name: taille; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".taille VALUES (1, 'xs', '53/54');
INSERT INTO "BMWMottorad".taille VALUES (2, 's', '55/56');
INSERT INTO "BMWMottorad".taille VALUES (3, 'm', '57/58');
INSERT INTO "BMWMottorad".taille VALUES (4, 'l', '58/59');
INSERT INTO "BMWMottorad".taille VALUES (5, 'xl', '60/61');
INSERT INTO "BMWMottorad".taille VALUES (6, '2xl', '62/63');
INSERT INTO "BMWMottorad".taille VALUES (7, '3xl', '64/65');
INSERT INTO "BMWMottorad".taille VALUES (8, 'xs', '34');
INSERT INTO "BMWMottorad".taille VALUES (9, 's', '36');
INSERT INTO "BMWMottorad".taille VALUES (10, 'm', '38');
INSERT INTO "BMWMottorad".taille VALUES (11, 'm', '40');
INSERT INTO "BMWMottorad".taille VALUES (12, 'l', '42');
INSERT INTO "BMWMottorad".taille VALUES (13, 'l', '44');
INSERT INTO "BMWMottorad".taille VALUES (14, 'xl', '46');
INSERT INTO "BMWMottorad".taille VALUES (15, '2xl', '48');
INSERT INTO "BMWMottorad".taille VALUES (16, 'one size', NULL);
INSERT INTO "BMWMottorad".taille VALUES (17, '30L', NULL);
INSERT INTO "BMWMottorad".taille VALUES (18, '36', NULL);
INSERT INTO "BMWMottorad".taille VALUES (19, '37', NULL);
INSERT INTO "BMWMottorad".taille VALUES (20, '38', NULL);
INSERT INTO "BMWMottorad".taille VALUES (21, '39', NULL);
INSERT INTO "BMWMottorad".taille VALUES (22, '40', NULL);
INSERT INTO "BMWMottorad".taille VALUES (23, '41', NULL);
INSERT INTO "BMWMottorad".taille VALUES (24, '42', NULL);
INSERT INTO "BMWMottorad".taille VALUES (25, '43', NULL);
INSERT INTO "BMWMottorad".taille VALUES (26, '44', NULL);
INSERT INTO "BMWMottorad".taille VALUES (27, '45', NULL);
INSERT INTO "BMWMottorad".taille VALUES (28, '46', NULL);
INSERT INTO "BMWMottorad".taille VALUES (29, '47', NULL);
INSERT INTO "BMWMottorad".taille VALUES (30, '48', NULL);
INSERT INTO "BMWMottorad".taille VALUES (31, '49', NULL);
INSERT INTO "BMWMottorad".taille VALUES (32, '50', NULL);
INSERT INTO "BMWMottorad".taille VALUES (33, '51', NULL);
INSERT INTO "BMWMottorad".taille VALUES (34, '52', NULL);
INSERT INTO "BMWMottorad".taille VALUES (35, '53', NULL);
INSERT INTO "BMWMottorad".taille VALUES (36, '54', NULL);
INSERT INTO "BMWMottorad".taille VALUES (37, '55', NULL);
INSERT INTO "BMWMottorad".taille VALUES (38, '56', NULL);
INSERT INTO "BMWMottorad".taille VALUES (39, '57', NULL);
INSERT INTO "BMWMottorad".taille VALUES (40, '58', NULL);
INSERT INTO "BMWMottorad".taille VALUES (41, '59', NULL);
INSERT INTO "BMWMottorad".taille VALUES (42, '60', NULL);
INSERT INTO "BMWMottorad".taille VALUES (43, '61', NULL);
INSERT INTO "BMWMottorad".taille VALUES (44, '62', NULL);
INSERT INTO "BMWMottorad".taille VALUES (45, '6', NULL);
INSERT INTO "BMWMottorad".taille VALUES (46, '7', NULL);
INSERT INTO "BMWMottorad".taille VALUES (47, '8', NULL);
INSERT INTO "BMWMottorad".taille VALUES (48, '9', NULL);
INSERT INTO "BMWMottorad".taille VALUES (49, '10', NULL);
INSERT INTO "BMWMottorad".taille VALUES (50, '11', NULL);
INSERT INTO "BMWMottorad".taille VALUES (51, '12', NULL);


--
-- Data for Name: contenucommande; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".contenucommande VALUES (1, 1, 1, 1, 4);
INSERT INTO "BMWMottorad".contenucommande VALUES (2, 2, 2, 1, 4);
INSERT INTO "BMWMottorad".contenucommande VALUES (3, 3, 2, 1, 4);
INSERT INTO "BMWMottorad".contenucommande VALUES (4, 4, 1, 1, 4);
INSERT INTO "BMWMottorad".contenucommande VALUES (5, 5, 1, 1, 4);
INSERT INTO "BMWMottorad".contenucommande VALUES (6, 6, 1, 1, 4);
INSERT INTO "BMWMottorad".contenucommande VALUES (7, 7, 1, 1, 4);
INSERT INTO "BMWMottorad".contenucommande VALUES (8, 8, 1, 1, 4);
INSERT INTO "BMWMottorad".contenucommande VALUES (9, 9, 1, 1, 4);
INSERT INTO "BMWMottorad".contenucommande VALUES (10, 10, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (11, 11, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (12, 12, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (13, 13, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (14, 14, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (15, 15, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (16, 16, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (17, 17, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (18, 18, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (19, 19, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (20, 20, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (21, 21, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (22, 22, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (23, 23, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (24, 24, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (25, 25, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (26, 26, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (27, 27, 1, 2, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (28, 1, 1, 3, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (29, 2, 1, 3, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (30, 3, 1, 3, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (31, 4, 1, 3, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (32, 5, 1, 3, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (33, 6, 1, 3, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (34, 7, 1, 3, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (35, 8, 1, 3, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (36, 9, 1, 3, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (37, 10, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (38, 11, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (39, 12, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (40, 13, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (41, 14, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (42, 15, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (43, 16, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (44, 17, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (45, 18, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (46, 19, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (47, 20, 1, 4, 10);
INSERT INTO "BMWMottorad".contenucommande VALUES (48, 1, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (49, 1, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (50, 2, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (51, 2, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (52, 2, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (53, 2, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (54, 3, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (55, 4, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (56, 5, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (57, 6, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (58, 7, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (59, 8, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (60, 9, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (61, 9, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (62, 6, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (63, 5, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (64, 4, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (65, 3, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (66, 4, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (67, 3, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (68, 2, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (69, 4, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (70, 3, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (71, 2, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (72, 1, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (73, 3, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (74, 6, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (75, 7, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (76, 5, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (77, 4, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (78, 6, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (79, 5, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (80, 8, 1, 5, 15);
INSERT INTO "BMWMottorad".contenucommande VALUES (129, 1, 1, 1, 16);
INSERT INTO "BMWMottorad".contenucommande VALUES (133, 1, 4, 1, 16);
INSERT INTO "BMWMottorad".contenucommande VALUES (131, 4, 1, 1, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (96, 8, 4, 4, 2);
INSERT INTO "BMWMottorad".contenucommande VALUES (135, 1, 1, 1, 16);
INSERT INTO "BMWMottorad".contenucommande VALUES (136, 4, 1, 4, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (137, 6, 1, 8, 3);
INSERT INTO "BMWMottorad".contenucommande VALUES (137, 4, 2, 2, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (138, 1, 1, 1, 16);
INSERT INTO "BMWMottorad".contenucommande VALUES (139, 10, 1, 16, 1);
INSERT INTO "BMWMottorad".contenucommande VALUES (400, 1, 1, 1, 16);
INSERT INTO "BMWMottorad".contenucommande VALUES (401, 1, 1, 1, 16);
INSERT INTO "BMWMottorad".contenucommande VALUES (401, 6, 1, 8, 3);


--
-- Data for Name: couleur; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".couleur VALUES (1, 1, 'Black Storm metallic', 0, 'La peinture Black storm metallic souligne le caractère puissant de la moto. Le bras oscillant, les roues et les étriers de frein dans le ton noir complètent le look sombre. Les teintes sobres mettent d’autant plus en valeur le monogramme « S 1000 RR »', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/sport/s1000rr/2022/softconfigurator/s1000rr-P0ND2-softconfigurator-thumbnail.jpg.asset.1661501931495.jpg', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/sport/s1000rr/2022/softconfigurator/S1000RR-P0ND2-softconfigurator.jpg.asset.1661501931990.jpg');
INSERT INTO "BMWMottorad".couleur VALUES (2, 2, 'Black Storm metallic', 0, 'La peinture Black storm metallic du modèle de base confère à la moto un look particulièrement dynamique et puissant.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/tour/k1600gtl-2021/2023/softkonfigurator/nsc-k1600gtl-P0ND2-softconfigurator-thumbnail.jpg.asset.1686756193279.jpg', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/tour/k1600gtl-2021/2023/softkonfigurator/nsc-k1600gtl-P0ND2-softconfigurator.jpg.asset.1686756194178.jpg');
INSERT INTO "BMWMottorad".couleur VALUES (3, 3, 'Black Storm metallic', 0, 'La peinture Black storm metallic confère à la moto une élégance remarquable.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/heritage/r18_classic/2023/softcconfigurator/nsc-r18-classic-P0ND2-softconfigurator-thumbnail.jpg.asset.1686752276034.jpg', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/heritage/r18_classic/2023/softcconfigurator/nsc-r18-classic-P0ND2-softconfigurator.jpg.asset.1686752276339.jpg');
INSERT INTO "BMWMottorad".couleur VALUES (4, 3, 'Manhattan metallic matt', 355, 'La peinture Manhattan métallisée mate confère à la moto un style à la fois élégant et expressif. Le moteur et la boîte de vitesses en argent Nürburg, les pièces en aluminium et le guidon en chrome brillant offrent un somptueux contraste avec les surfaces peintes sombres et la selle noire.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/heritage/r18_classic/2023/softcconfigurator/nsc-r18-classic-P0N3M-softconfigurator-thumbnail.jpg.asset.1686752275642.jpg', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/heritage/r18_classic/2023/softcconfigurator/nsc-r18-classic-P0N3M-softconfigurator.jpg.asset.1686752275995.jpg');
INSERT INTO "BMWMottorad".couleur VALUES (5, 4, 'Lightwhite uni', 0, 'Grâce à la peinture Light white uni, la moto fait preuve d’un style à la fois léger et sportif. La selle noire et bleue avec piqûre GS et le guidon noir génèrent des contrastes captivants avec les surfaces peintes claires.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/adventure/f800gs-2023/softconfigurator/nsc-f800gs-P0NB5-softconfigurator-thumbnail.jpg.asset.1693839015111.jpg', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/adventure/f800gs-2023/softconfigurator/nsc-f800gs-P0NB5-softconfigurator.jpg.asset.1693839015549.jpg');
INSERT INTO "BMWMottorad".couleur VALUES (6, 1, 'Light white/M Motorsport', 4640, 'Le pack M avec la peinture Lightwhite uni/M Motorsport, les étriers de frein M bleus et les repose-pieds M confèrent à la moto un look puissant. La selle sport M offre au pilote une tenue optimale pour la chasse aux dixièmes de seconde décisifs. Les roues en carbone M allégées offrent un maximum de dynamisme.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/sport/s1000rr/2022/softconfigurator/s1000rr-P0N3H-softconfigurator-thumbnail.jpg.asset.1663315950881.jpg', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/sport/s1000rr/2022/softconfigurator/S1000RR-P0N3H-softconfigurator.jpg.asset.1661501925748.jpg');


--
-- Data for Name: demandeessai; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".demandeessai VALUES (1, 1, 1, 1, 'j''aimerai voir la photo avant de l''acheter comme cadeau à mon père');
INSERT INTO "BMWMottorad".demandeessai VALUES (2, 1, 2, 2, 'ça sera bien de voir si la mtot vaut son prix');
INSERT INTO "BMWMottorad".demandeessai VALUES (3, 2, 3, 3, 'j''adore les motos');
INSERT INTO "BMWMottorad".demandeessai VALUES (4, 4, 4, 4, 'mes parents vont m''offrir une moto pour l''anniversaire, mais j''aimerai la tester avant');
INSERT INTO "BMWMottorad".demandeessai VALUES (5, 5, 4, 5, 'c''est pour un cadeau pour pascal colin');
INSERT INTO "BMWMottorad".demandeessai VALUES (6, 1, 1, 23, 'oziutjz');
INSERT INTO "BMWMottorad".demandeessai VALUES (7, 1, 1, 25, 'jador mles mot');
INSERT INTO "BMWMottorad".demandeessai VALUES (8, 1, 1, 27, 'Jadore la moto');
INSERT INTO "BMWMottorad".demandeessai VALUES (9, 2, 1, 29, 'I like motorbikes');
INSERT INTO "BMWMottorad".demandeessai VALUES (12, 1, 3, 51, 'srgzrgrzeg');
INSERT INTO "BMWMottorad".demandeessai VALUES (13, 2, 3, 53, 'zujzg');
INSERT INTO "BMWMottorad".demandeessai VALUES (14, 5, 1, 55, 'I love motorbikes');
INSERT INTO "BMWMottorad".demandeessai VALUES (15, 1, 1, 57, 'Bonjour, j''aimerais essayer la moto Btw normalement on est pas censés devoir renseigner les infos quand on est déjà connecté au compte ^^');
INSERT INTO "BMWMottorad".demandeessai VALUES (16, 1, 1, 59, 'zomgihjzlogerlgerlrehj');
INSERT INTO "BMWMottorad".demandeessai VALUES (20, 4, 3, 61, 'hehe');


--
-- Data for Name: option; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".option VALUES (3, 'Chaine Endurance M', 160, 'Davantage de puissance sur la roue arrière : La chaîne M Endurance associée à des galets avec revêtement DLC se caractérise par une réduction des frottements et de l’entretien. Le revêtement en carbone présente une dureté comparable à celle du diamant et minimise les pertes de rendement. Le revêtement DLC (Diamond-Like Carbon) simplifie également l’entretien.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3cnjifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (2, 'Capot selle (sans selle)', 115, 'Le cache de selle passager élégant assure un look sportif.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3ll7ifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (6, 'M Systeme d''Echappement titane', 2451, 'le système d’échappement M Titan d’Akrapovič avec embout en carbone souligne non seulement l’esthétique sportive de la moto, mais augmente aussi ses performances. Par rapport au système de série, il permet de réduire significativement le poids et d’augmenter le couple moteur, en particulier à mi-régimes. Il en résulte une réponse de la poignée des gaz d’une grande sensibilité dans tous les modes de pilotage.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3cvfifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (4, 'DDC Dynamic Damping Control', 760, 'Le Dynamic Damping Control (DDC) adapte l’amortissement du châssis à la situation de conduite actuelle et assure des performances supérieures grâce à un meilleur contact avec la chaussée. Le système réagit aux manœuvres de conduite telles que le freinage, l’accélération ou les virages de manière entièrement automatique, et ajuste l’amortissement à la perfection en quelques millisecondes.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3yK5ifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (7, 'Silencieux Sport', 895, 'Le nec plus ultra du haut de gamme : le silencieux Sport slip-on en titane de haute qualité avec embout en carbone délivre un son plus affirmé et souligne l’esthétique sportive. Le poids du silencieux Sport développé par Akrapovič a également été optimisé par rapport au silencieux de série.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3cvzifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (5, 'Jantes Forgees M', 4, 'Les jantes forgées M anodisées noires réduisent les forces gyroscopiques pour plus d’agilité. Grâce à des disques de frein de 5 mm, elles offrent des performances de freinage supérieures – sur circuit comme sur route.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3ZvDifGH3dTUw8jgL3hSntD0nBdKVZjYpMdbhM');
INSERT INTO "BMWMottorad".option VALUES (10, 'Option 719 Billet pack Aero', 1000, 'L’option 719 &#59 pack design Aero évoque le look inimitable de la Streamliner des années 1930. Les surfaces brossées de la pièce et le revêtement transparent confèrent un style d’époque à ce pack composé du couvercle frontal, du couvre-culasses et du cache de coude d’admission. Les capots en tôle présentent par ailleurs des passages d’air typiques.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZ5j2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3ZvlifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (11, 'Option 719 Roue Aero', 790, 'L’option 719 - Jante Aero de coloris argenté confère une touche individuelle à la moto. Cette jante moulée à 6 rayons présente des nervures fraisées.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZ5j2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc36lmifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (12, 'Option 719 Roue Icon', 790, 'L’option 719 - Jante Icon de coloris noir mat confère une touche individuelle à la moto. Cette jante moulée à 6 rayons présente des nervures fraisées.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZ5j2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc36ljifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (13, 'Selle Option 719', 325, 'La selle noire Option 719, avec ses surpiqûres en losange, impressionne par son look raffiné. Le revêtement de la selle a deux grains différents et s’adapte parfaitement à toutes les peintures disponibles. La selle est dotée sur le côté d’un fanion Option 719.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZ5j2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3Om4ifG70qbX0x1RCzPheU1vGUU');
INSERT INTO "BMWMottorad".option VALUES (15, 'ESA Dynamic', 395, 'Le Dynamic ESA (Electronic Suspension Adjustment) régule automatiquement l’amortissement de la jambe de suspension en fonction de la conduite. Trois niveaux différents d’adaptation des amortisseurs (Road, Dynamic et Enduro) peuvent être sélectionnés pendant la conduite et la précontrainte de ressort peut être réglée à l’arrêt d’une simple pression sur un bouton.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3cvFifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (1, 'Appel d''urgence intelligent', 367, 'En cas d’accident, l’appel d’urgence intelligent contacte automatiquement le centre d’appels BMW pour activer la chaîne de sauvetage aussi rapidement que possible. La position du véhicule est alors communiquée et, si possible, une première conversation est établie avec la personne concernée. Le système peut aussi être activé manuellement, par exemple pour assister d’autres usagers de la route.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3lscifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (8, 'Option 719 Spezial jantes forgees class', 1615, 'Les jantes forgées Classic de qualité supérieure font partie intégrante de l’équipement en option très design du programme Option 719. Les pièces exclusives soulignent le caractère unique de la machine et lui confèrent un look exceptionnel sur la route.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZyd2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3ZvFifGH3dTUw8jgL3hSntD0nBdKVZjYpMdbhM');
INSERT INTO "BMWMottorad".option VALUES (9, 'Selle Option 719', 220, 'La selle raffinée de l’option 719 se présente dans un marron classique. Elle séduit par un toucher délicat, une marbrure discrète, des coutures décoratives de haute qualité et un gaufrage losange attrayant. Le monogramme GT brodé complète le design exclusif. Cette selle est chauffante et sa hauteur est la même que la selle de série.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZ5j2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3ZvlifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (14, 'Bridage 48cv', 0, 'La réduction de puissance à 35 kW (48 ch) permet également aux nouveaux détenteurs du permis UE jusqu’à 25 ans (catégorie A2) de profiter, départ usine, de vraies sensations moto. Le plaisir de conduite reste cependant inchangé. Sur demande, le moteur peut être ramené plus tard à sa pleine puissance.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3wleifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (16, 'Keyless ride', 235, 'Grâce au système Keyless Ride, la clé de contact restera désormais dans votre poche. Ce système sans clé est extrêmement convivial et permet au conducteur de démarrer sa machine par simple pression d’un bouton. L’antivol de direction et le bouchon du réservoir peuvent également être déverrouillés de cette façon. Il ne vous reste plus qu’à enfourcher votre machine et à prendre la route !', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3cv5ifG70qbX0x1RCzPheU1vGU');
INSERT INTO "BMWMottorad".option VALUES (17, 'Feu diurne', 0, 'Le feu de jour à LED intégré au projecteur garantir une meilleure sécurité dans le trafic. De jour, il améliore la visibilité de la moto grâce à sa technologie LED moderne.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZNc2uzHVPRdgSht5gJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3yl7ifG70qbX0x1RCzPheU1VSe');
INSERT INTO "BMWMottorad".option VALUES (18, 'Oil Inclusive 3ans / 30 000 km', 370, '///', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZNc2uzHVPRdgSht5gJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3ZseifG70qbX0x1RCzPheU1VSe');
INSERT INTO "BMWMottorad".option VALUES (20, 'Batterie M', 210, 'Grandes performances, faible poids : La batterie de qualité supérieure Lightweight M bénéficie d’une technologie lithium-ion à la pointe de la modernité et pèse jusqu’à 2,9 kg de moins que la batterie montée en série. L’aide au démarrage parfaite pour les pilotes ambitieux désirant optimiser le poids de leur machine au gramme près.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZdE2uzHVPRdgSht5gJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc36%25mifG70qbX0x1RCzPheU1VSr');
INSERT INTO "BMWMottorad".option VALUES (21, 'oui', 44444, 'test', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTC8qFWtBQge5YeBShkg1nfY2L1PJNbrxqn4A&usqp=CAU');


--
-- Data for Name: style; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".style VALUES (5, 'Style Sport', 215, 'En déclinaison Sport, la machine se présente dans le coloris dynamique Racing blue metallic. La selle noire et rouge est dotée du logo GS cousu qui accroche le regard. Les caches de radiateur en Light white uni, ainsi que le guidon argenté, génèrent des contrastes captivants. La bulle teintée complète l’esthétique sportive.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/adventure/f800gs-2023/softconfigurator/nsc-f800gs-P0N2L-softconfigurator-thumbnail.jpg.asset.1693839014662.jpg', 4, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/adventure/f800gs-2023/softconfigurator/nsc-f800gs-P0N2L-softconfigurator.jpg.asset.1693839015016.jpg');
INSERT INTO "BMWMottorad".style VALUES (6, 'Style Triple Black', 215, 'Dans la déclinaison Triple Black, la moto se pare d’une élégance discrète. Les surfaces de peinture en Black storm metallic, combinées aux caches de radiateur en Mineral grey metallic mat et à la selle noire et grise, donnent un look ton sur ton captivant.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/adventure/f800gs-2023/softconfigurator/nsc-f800gs-P0ND2-softconfigurator-thumbnail.jpg.asset.1693839015753.jpg', 4, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/adventure/f800gs-2023/softconfigurator/nsc-f800gs-P0ND2-softconfigurator.jpg.asset.1693839016418.jpg');
INSERT INTO "BMWMottorad".style VALUES (2, 'Style Exclusive', 750, 'En Style Exclusive, la moto se pare d’une peinture GravityBlue métallisée à la fois sportive et raffinée. Le garde-boue arrière et les cache-radiateurs en Monolith métallisé mat sont parfaitement assortis. Le cache de réservoir en Blackstorm métallisé, les caches des déflecteurs de vent chromés brillants et la baguette chromée de la valise viennent compléter l’allure exclusive.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/tour/k1600gtl-2021/2023/softkonfigurator/nsc-k1600gtl-P0N3N-softconfigurator-thumbnail.jpg.asset.1686756193678.jpg', 2, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/tour/k1600gtl-2021/2023/softkonfigurator/nsc-k1600gtl-P0N3N-softconfigurator.jpg.asset.1686756194385.jpg');
INSERT INTO "BMWMottorad".style VALUES (3, 'Option 719 Havanna', 3530, 'La variante de modèle Option 719 « Hanovre » se distingue par son style et son assurance. La peinture Meteoric Dust metallic produit un effet de profondeur spectaculaire et attire tous les regards. Un liseré manuel élégant et des éléments chromés stylés viennent compléter l''esthétique. Autre élément qui attire le regard : la plaquette Option 719 valorisante sur le réservoir.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/tour/k1600gtl-2021/2023/softkonfigurator/nsc-k1600gtl-P0H0L-softconfigurator-thumbnail.jpg.asset.1686756193616.jpg', 2, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/tour/k1600gtl-2021/2023/softkonfigurator/nsc-k1600gtl-P0H0L-softconfigurator.jpg.asset.1687853537798.jpg');
INSERT INTO "BMWMottorad".style VALUES (4, 'Style Option 719', 2900, 'La variante de modèle Option 719 « Moon Stone » combine des contrastes saisissants pour former un ensemble stylé. La couleur principale blanc minéral est complétée par des touches de Meteoric Dust et Aurum. La chaîne cinématique noire, le siège Option 719, la roue Aero et de nombreux autres détails haut de gamme attirent tous les regards.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/heritage/r18_classic/2023/softcconfigurator/nsc-r18-classic-P0H0A-softconfigurator-thumbnail.jpg.asset.1686752274898.jpg', 3, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/heritage/r18_classic/2023/softcconfigurator/nsc-r18-classic-P0H0A-softconfigurator.jpg.asset.1686752275222.jpg');
INSERT INTO "BMWMottorad".style VALUES (1, 'Style Passion', 375, 'Dans le Style Passion, la peinture Racing red uni confère à la moto un petit quelque chose en plus et attire tous les regards. Des détails noirs tels que les jantes, les étriers de frein et le bras oscillant créent des contrastes saisissants avec la peinture voyante. Un monogramme « S 1000 RR » vient compléter le look dynamique.', 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/sport/s1000rr/2022/softconfigurator/s1000rr-P0NA5-softconfigurator-thumbnail.jpg.asset.1661501925772.jpg', 1, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/sport/s1000rr/2022/softconfigurator/S1000RR-P0NA5-softconfigurator.jpg.asset.1661501931370.jpg');


--
-- Data for Name: est_inclus; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".est_inclus VALUES (1, 1);
INSERT INTO "BMWMottorad".est_inclus VALUES (3, 2);
INSERT INTO "BMWMottorad".est_inclus VALUES (5, 3);
INSERT INTO "BMWMottorad".est_inclus VALUES (9, 3);
INSERT INTO "BMWMottorad".est_inclus VALUES (8, 3);
INSERT INTO "BMWMottorad".est_inclus VALUES (14, 4);
INSERT INTO "BMWMottorad".est_inclus VALUES (10, 4);
INSERT INTO "BMWMottorad".est_inclus VALUES (11, 4);
INSERT INTO "BMWMottorad".est_inclus VALUES (13, 4);
INSERT INTO "BMWMottorad".est_inclus VALUES (4, 5);
INSERT INTO "BMWMottorad".est_inclus VALUES (2, 5);
INSERT INTO "BMWMottorad".est_inclus VALUES (9, 6);


--
-- Data for Name: est_lie; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".est_lie VALUES (1, 20);
INSERT INTO "BMWMottorad".est_lie VALUES (5, 19);
INSERT INTO "BMWMottorad".est_lie VALUES (7, 9);
INSERT INTO "BMWMottorad".est_lie VALUES (10, 16);
INSERT INTO "BMWMottorad".est_lie VALUES (16, 11);
INSERT INTO "BMWMottorad".est_lie VALUES (12, 4);
INSERT INTO "BMWMottorad".est_lie VALUES (11, 1);
INSERT INTO "BMWMottorad".est_lie VALUES (4, 5);
INSERT INTO "BMWMottorad".est_lie VALUES (3, 7);
INSERT INTO "BMWMottorad".est_lie VALUES (6, 12);


--
-- Data for Name: garage; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".garage VALUES (1, 1);
INSERT INTO "BMWMottorad".garage VALUES (2, 1);
INSERT INTO "BMWMottorad".garage VALUES (3, 1);
INSERT INTO "BMWMottorad".garage VALUES (4, 2);
INSERT INTO "BMWMottorad".garage VALUES (5, 4);
INSERT INTO "BMWMottorad".garage VALUES (6, 6);
INSERT INTO "BMWMottorad".garage VALUES (7, 7);
INSERT INTO "BMWMottorad".garage VALUES (8, 8);
INSERT INTO "BMWMottorad".garage VALUES (9, 9);
INSERT INTO "BMWMottorad".garage VALUES (10, 14);
INSERT INTO "BMWMottorad".garage VALUES (11, 45);
INSERT INTO "BMWMottorad".garage VALUES (12, 34);
INSERT INTO "BMWMottorad".garage VALUES (13, 23);
INSERT INTO "BMWMottorad".garage VALUES (14, 28);
INSERT INTO "BMWMottorad".garage VALUES (15, 23);
INSERT INTO "BMWMottorad".garage VALUES (16, 41);
INSERT INTO "BMWMottorad".garage VALUES (17, 41);
INSERT INTO "BMWMottorad".garage VALUES (18, 23);
INSERT INTO "BMWMottorad".garage VALUES (19, 50);
INSERT INTO "BMWMottorad".garage VALUES (20, 50);


--
-- Data for Name: infocb; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".infocb VALUES (15, 72, 'eyJpdiI6IjdJUHY0Y2lsamVrdXorZ3JWWkxMOGc9PSIsInZhbHVlIjoiUEdGdWJBWUNEK2wwR2JBQU1QU3pKSUlaeDVJS01tMno1akVhRUw0cFNIaz0iLCJtYWMiOiJlNDkxMTVjNDIzMDhhMmI2M2JlNjA4ZDMwZDg2MjQ4YjA4ZTZmMTdkZDY2NDc1OTFkYzVjZDAyOWExY2YwZjk1IiwidGFnIjoiIn0=', 'eyJpdiI6Ik11WFJobEpKVEF3ZXU5OHhvaXE1eUE9PSIsInZhbHVlIjoidmhmb2h4NXNKUDhqUmVaM0NkSHhNQT09IiwibWFjIjoiZWI3MjRjYWM2ZTdmZmUzN2U2MjQyYTQ4YjI4NzgzMDVjODc1MTliYTVkZDE3MzgyNTE5MmRlZTViNTQyYjE3NiIsInRhZyI6IiJ9', 'eyJpdiI6Ii9NNkxvVk5hRVN5RDg5ajFKSVNpdGc9PSIsInZhbHVlIjoidW5SZG1iR1FZV28wVTYvUVo2TWZaQT09IiwibWFjIjoiZTNlYTg5ZmU1NmFlNDQwZmJlMjQyNTNmZDhlNmNlOTQxNjQxNDIwNmMzM2ViMTRlNGYzYjdhMGM1YzgxMmExMyIsInRhZyI6IiJ9');
INSERT INTO "BMWMottorad".infocb VALUES (20, 201, 'eyJpdiI6ImFaUU8vSE5tUnlxeUgzTjNNeEJBeEE9PSIsInZhbHVlIjoiQWlWclVyclZYdldBcVJWSnVGZ1k0YlRiSFRrSXRKbUE3VmVxaXNaVlpXbz0iLCJtYWMiOiI4MDk3NWFkOWQyY2RlMzFjNzRhOTljMjRkZjFiNTk1OGIzYmIzYmI5NjMyMzY2MTlhZDhhYzA3ZjI4OWQ5ZjI0IiwidGFnIjoiIn0=', 'eyJpdiI6IlNYeUZYQnNmeEsxMndCWjllc3FiRmc9PSIsInZhbHVlIjoiMitNd3lmZUVtbFdxbUROM1huZ1dMUT09IiwibWFjIjoiMDUzODQ4NmJlODM0OGI0ZDM4NjI5NzkyZDI5OTQxZThmZmQwNDE4YTQxYzE0OWY4M2RkZWIxYTg2NDkwYmQwNCIsInRhZyI6IiJ9', 'eyJpdiI6Imh2L0dJRmp2Wm5uNnF1OWlpcFlKNHc9PSIsInZhbHVlIjoiSmVtaHJnNHRkYTA4VVVaYk4raThGUT09IiwibWFjIjoiMTFhZjM0YmU3NmJmOGVhMzY0YWIxYWI2NzEyMmIyYzNmZTJlZTRjMDFiOTk3ZDgyNGY3NzFkOWY4MWVmZDgzNyIsInRhZyI6IiJ9');


--
-- Data for Name: presentation_eq; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".presentation_eq VALUES (1, 6, 4);
INSERT INTO "BMWMottorad".presentation_eq VALUES (2, 6, 3);
INSERT INTO "BMWMottorad".presentation_eq VALUES (3, 1, 16);
INSERT INTO "BMWMottorad".presentation_eq VALUES (4, 1, 17);
INSERT INTO "BMWMottorad".presentation_eq VALUES (5, 10, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (6, 11, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (7, 12, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (8, 13, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (9, 13, 30);
INSERT INTO "BMWMottorad".presentation_eq VALUES (10, 14, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (11, 15, 13);
INSERT INTO "BMWMottorad".presentation_eq VALUES (12, 15, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (13, 16, 31);
INSERT INTO "BMWMottorad".presentation_eq VALUES (14, 17, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (15, 18, 32);
INSERT INTO "BMWMottorad".presentation_eq VALUES (16, 19, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (17, 5, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (18, 4, 2);
INSERT INTO "BMWMottorad".presentation_eq VALUES (19, 4, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (20, 7, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (21, 9, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (22, 8, 5);
INSERT INTO "BMWMottorad".presentation_eq VALUES (23, 2, 23);
INSERT INTO "BMWMottorad".presentation_eq VALUES (24, 2, 24);
INSERT INTO "BMWMottorad".presentation_eq VALUES (25, 2, 25);
INSERT INTO "BMWMottorad".presentation_eq VALUES (26, 2, 26);
INSERT INTO "BMWMottorad".presentation_eq VALUES (27, 2, 27);
INSERT INTO "BMWMottorad".presentation_eq VALUES (28, 2, 28);
INSERT INTO "BMWMottorad".presentation_eq VALUES (29, 2, 29);
INSERT INTO "BMWMottorad".presentation_eq VALUES (30, 20, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (31, 21, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (32, 22, 13);
INSERT INTO "BMWMottorad".presentation_eq VALUES (33, 23, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (34, 25, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (35, 26, 6);
INSERT INTO "BMWMottorad".presentation_eq VALUES (36, 27, 6);
INSERT INTO "BMWMottorad".presentation_eq VALUES (37, 24, 1);
INSERT INTO "BMWMottorad".presentation_eq VALUES (38, 1, 18);
INSERT INTO "BMWMottorad".presentation_eq VALUES (39, 1, 19);
INSERT INTO "BMWMottorad".presentation_eq VALUES (40, 1, 20);
INSERT INTO "BMWMottorad".presentation_eq VALUES (41, 1, 21);
INSERT INTO "BMWMottorad".presentation_eq VALUES (42, 1, 22);
INSERT INTO "BMWMottorad".presentation_eq VALUES (43, 3, 18);
INSERT INTO "BMWMottorad".presentation_eq VALUES (44, 3, 33);
INSERT INTO "BMWMottorad".presentation_eq VALUES (45, 3, 19);
INSERT INTO "BMWMottorad".presentation_eq VALUES (46, 3, 22);
INSERT INTO "BMWMottorad".presentation_eq VALUES (47, 3, 34);
INSERT INTO "BMWMottorad".presentation_eq VALUES (48, 3, 35);
INSERT INTO "BMWMottorad".presentation_eq VALUES (49, 3, 36);
INSERT INTO "BMWMottorad".presentation_eq VALUES (50, 28, 24);
INSERT INTO "BMWMottorad".presentation_eq VALUES (51, 28, 19);
INSERT INTO "BMWMottorad".presentation_eq VALUES (52, 28, 38);
INSERT INTO "BMWMottorad".presentation_eq VALUES (53, 28, 15);
INSERT INTO "BMWMottorad".presentation_eq VALUES (54, 28, 37);
INSERT INTO "BMWMottorad".presentation_eq VALUES (55, 28, 39);


--
-- Data for Name: media; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".media VALUES (253, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6626gtKt1qvqsiXyM8oWcquQmZoBoprdOKe3Rl1fzzNJNRbrtxC78z57O8Si4sVWqBm5adUQ7QEku3A2nCLYUcV2R28MFIhTDoh3zFW%25eneyaBYvxZIQIYADF9AvnGRM7ESp1o1H', 46, false);
INSERT INTO "BMWMottorad".media VALUES (254, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3756ym7JemXJYyHsOiPwQsmGY6i1Y04DBEiiPw4iW1vYeZEQOIP1EA3dEhq1Eg7mpyYmkbei1Yr%25sivR2YNMJkBvYeTpyvAdF75ZyM4rx9gRQuqSIHvYeI8x2KenMIhvc1WjvYeI', 46, false);
INSERT INTO "BMWMottorad".media VALUES (49, 11, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2356sENXYEcX1s3FGuqSxFEH1fuk1IB76AuuqSBuDki1YWAxGpqkAvZRAyCkA9NE%25s1EgLYuk1KdFuiPw1OmXg6i1Yr%25sivR2NbWsmBKMJ9PxQCap3i1YXTCemYtmpyiekDti1Yq', 6, false);
INSERT INTO "BMWMottorad".media VALUES (9, NULL, 1, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/sport/s1000rr/2022/softconfigurator/S1000RR-P0N3H-softconfigurator.jpg.asset.1661501925748.jpg', NULL, true);
INSERT INTO "BMWMottorad".media VALUES (10, NULL, 2, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/tour/k1600gtl-2021/2023/softkonfigurator/nsc-k1600gtl-P0N3N-softconfigurator.jpg.asset.1686756194385.jpg', NULL, true);
INSERT INTO "BMWMottorad".media VALUES (11, NULL, 3, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/heritage/r18_classic/2023/softcconfigurator/nsc-r18-classic-P0ND2-softconfigurator.jpg.asset.1686752276339.jpg', NULL, true);
INSERT INTO "BMWMottorad".media VALUES (12, NULL, 4, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/adventure/f800gs-2023/softconfigurator/nsc-f800gs-P0N2L-softconfigurator.jpg.asset.1693839015016.jpg', NULL, true);
INSERT INTO "BMWMottorad".media VALUES (13, NULL, 4, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/adventure/f800gs-2023/softconfigurator/nsc-f800gs-P0ND2-softconfigurator.jpg.asset.1693839016418.jpg', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (14, NULL, 1, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/sport/s1000rr/2022/tabbed-content/s1000rr-P0N3H-m-paket.jpg.asset.1663082035940.jpg.16_9_1920.jpg', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (15, NULL, 1, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/sport/s1000rr/2022/tabbed-content/s1000rr-P0N3H-racepaket.jpg.asset.1661934616765.jpg.16_9_1920.jpg', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (16, NULL, 1, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/multiimages/images/models/sport/s1000rr/2022/nsc-s1000rr-P0N3H-multiimage-2560x1440.jpg.asset.1661501760414.jpg', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (17, NULL, 1, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/sport/s1000rr/2022/tabbed-content/s1000rr-P0N3H-dynamikpaket.jpg.asset.1661934626589.jpg.16_9_1920.jpg', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (7, 8, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3837JsvYocyCQbHITjonCaZnw3F71idL7wqEQiv4RNuUbb6sMCxzUld8ip32fMxMiA8Lvrg7B2A4LiH7WCpI1j0UdQJ%25IcKUVu6JmtH3PXrOUb64C99aRuXtnb9kwy8G6h87d9o8', 22, false);
INSERT INTO "BMWMottorad".media VALUES (18, NULL, 2, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/tour/k1600gtl-2021/teaser/nsc-k1600gtl-P0N3N-k1600ga-columnteaser.jpg.asset.1635350774632.jpg.16_9_480.jpg', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (19, NULL, 2, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/tour/k1600gtl-2021/sound/nsc-k1600gtl-P0N3N-sound-desktop.jpg.asset.1634306618388.jpg', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (20, NULL, 2, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/multiimages/images/models/tour/k1600gtl-2021/productstage/nsc-k1600gtl-P0ND2-multiimage-2560x1440.jpg.asset.1650953858732.jpg', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (21, NULL, 3, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/heritage/r18_classic/2021/movingimage/R18-Classic-nsc-master_movingimage.jpg.asset.1624269196149.jpg', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (22, NULL, 3, 'https://www.bmw-motorrad.fr/content/dam/bmwmotorradnsc/common/images/models/modell-teaser/columnteaser/heritage/columnteaser_r18_pure.jpg.asset.1586422399870.jpg.16_9_480.jpg', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (5, 7, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4657qhoDFM%25jvMvH35QKY6KNRaaBZ96sy8XdJsG3q4qSY8ZFU29XzOdNdDqC3xtqewpDEIOUYPfbmIrCkKqkWwllnE8sOu6vonobaf2W97hP5NfQ2fM%25j3vZC%25IE2ObKk%25cWcGFo', 20, false);
INSERT INTO "BMWMottorad".media VALUES (47, 10, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3341TN892dbMoXZHAJfIlarQbY3PekUrk3fQk6IsX%25MsNVsWy0eZeS1nvOhz8Vwu1BbyUNcoZ47mcQraiQYB12VcmtvI7qYLRsLfLY9L4Ywy1SEe0Lq4Ax9yDZ6aZnwt7LPfle2B', 5, false);
INSERT INTO "BMWMottorad".media VALUES (6, 9, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7967a1yDrnx169xPbwIv6B3bM5kR7QERfcLpAO9uU%250nyIE1SymsSEjURq9iMLs%25vGAQ5GOO8EnHJR7ej9tzZKvFglAw%25nyPMSn1WSBa4OT9FuG9yXjicBQgKDAk1j6OSvHwBGrI', 21, false);
INSERT INTO "BMWMottorad".media VALUES (255, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5843261QlPS1dIPEvVdeNnkQ26fKx3nff6GwH4uM2nSBW5x6X5DOjESA8A2SA%25ehDzavdhmkDhnrp8g87cyGEbVnYq54iPUP1YgU5nzADQzanAnq5T%25FcKpwQk2UlEUeG8NvGElc', 46, false);
INSERT INTO "BMWMottorad".media VALUES (8, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3030SOtaRSDJrilYI0IdJZ5PNB7bwjXuzNkjtUKAg5nCQAv3jXjvCMYZj9zHAVTnUrWuoPyBQOrAuTz5l9gcSqg%25eo29cFPqIKA2jqLzY8pf0xMAXySDJjyqRSPJZWN5MDGzgsRN', NULL, false);
INSERT INTO "BMWMottorad".media VALUES (4, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6051Pe6qv%25kVlZajuxAMVXyi1SX8RLTWF1oL6lbNT2zvON3kBjLOvHjYLUh1Nbzzl5cWfxIh3J5NWzSyaUTU%25AjiVfIrU0EuAfWIzuhhTRQsE7HNjd%25kVBIuQ6gdY91yHeXFnpv1', 18, false);
INSERT INTO "BMWMottorad".media VALUES (277, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-18180oI14z3KyjNEy%25ANsh1FNhnQeGZAhtsiN1VNBMibCADK0%25GpRNBziujWNs0iN1WNsX9gRD61tEgt6UB2g5Z%25osNIAB%25ANR5tXIh0SJ4o0G1t%25tz3KJUEmA4dn621IDYPSJ4e', 49, false);
INSERT INTO "BMWMottorad".media VALUES (286, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4063thpvEaxEmtptCafVFrwIvcaxE5cpcwFafVgwImaxEpFFI55ihwI5ao6mwEIafVmwEcQaxEOfV2afVQIwuQcaxEOfV2afVPJprwcNaxEL2afV5paxEA3Of3OAafVwvEIWaxEj', 50, false);
INSERT INTO "BMWMottorad".media VALUES (51, 11, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5428jSPuEwviEjCoIaBrSK2qxYauQleI9hwaBrXS0QsmE08Spz6MswCByTBQhvIwloE2xkMauQ3ztys5ViP8Qu9smE7lowS4TCJ0n8e72AvLsFbnzCsmEmNbMFiZhfjyQA0HsmEr', 6, false);
INSERT INTO "BMWMottorad".media VALUES (53, 12, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4247LysalWJHmXzM1v8t5Wckejw0sDyWKsfV3IlpP0t4r3Ca2Y3jm0dnKQxYCvsrNPeqAHykjeXfcV1uFD0La6sADMQ1xNESKsioPxrZbSfuu%25LkYnNeWuuXOvcLhj31TYxD6slQ', 7, false);
INSERT INTO "BMWMottorad".media VALUES (55, 12, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7453RnIgzBHj2oDEFqM7FFXyNsrvcH7xat2MWYnHbQil%25MWj%25CNpq3LfuMo3N2dE7kNZhXXcpWf9TMgnbt4wXBH%25rSW0vzCmNq4rJpFR2J6jPOkUCKzWnhGpHtGCobyYpOJdSczJ', 7, false);
INSERT INTO "BMWMottorad".media VALUES (2, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4863ieU5fX4f6iUitXHukE9n50X4fZ0U09kXHuR9n6X4fUkknZZbe9nZXMG69fnXHu69f0lX4faHugXHuln9Ll0X4faHugXHuKqUE90SX4fDgXHuZUX4fDMgva44XHu95fnFX4fa', 43, false);
INSERT INTO "BMWMottorad".media VALUES (24, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2540dAMmqnLt15PXbkAwIjbblav3EoEowMPwtOdHHGF%25yt7AilKsg77a8c9zWXmSVG639nvf8Bzdb8BeEUN%25xCvYnc1fgncxyig2WgFUCvP9YH%255lhjzrYJGUCb6AFtfSf9V0iq1', 3, false);
INSERT INTO "BMWMottorad".media VALUES (23, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7229F6kM6Iscp0PAuoC9Wt1QwzbnvOt6ff38D5AQFnafN4vl9zDGViyxwmFSvRk2HBwAdyAJGwjoI89yGkS7M5VUkI45EdnPkkXKBj6EDxbyrxjRzTdw1ql7398oBiK97S7vHv6G', 3, false);
INSERT INTO "BMWMottorad".media VALUES (296, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-29393aGLqRtyE8jkiOgTMmLmnvwc5VKXQSuknL2nRXJIWgUyODVHNjpCkX8TnuDJTBjTM4BfWU0zhebh0hREb0o32MnZYpDYnN%25Sf7m3vldaOKBSDFRtyvjFnYq%25s0iL7tb3Q6qW', 52, false);
INSERT INTO "BMWMottorad".media VALUES (306, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-493461IoqxSN5tXYOVam2%25f32tkmTozfV1SOUsuqtiG0c5P1PuKkj0n631ISIzCZKSap5XKfehgWV3zR7WrSjRfn7lHmgxUhA0Saann2so%25dnIGruhiFWzOzro25cBd4g8AwSjqe', 55, false);
INSERT INTO "BMWMottorad".media VALUES (268, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2843lrWpUSBW2ySPCe23MYDplrKJ%25vYKKrE4AoIdlYBTut%25rGtQmXPBqfqlBqF3zQj6C2zRDQzY9sf7fxH5EPVeYZato0S1SWZ71tYjqQpj6YqYatgFLHJs4pDxcUP13EfMCEPUK', 48, false);
INSERT INTO "BMWMottorad".media VALUES (278, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6639gp1aQi4RW%25ljNYt53ZaZ670owBLUGIOj6aC6iUnmJtfRYXBkelExjU%2556OXn5yl53hyFJfM2dTSdMdiWSMzgC369rEXr6eAIFcZg78vpYLyIXqi4R8qTKUQ9PMNac4SgGsQa', 49, false);
INSERT INTO "BMWMottorad".media VALUES (287, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4454wq%25%252Jr17VSOj3%25z2enVn4RMIJCg4%252bgiaivEby6gAIpoJ5WivbbZOjiNpbgijiNePoltnSnfoG%25XvSRhC3cNGnGk3%25zqZzmG4k8q2WOQSnozJr1OZighzkRzgnztOe8q2x', 50, false);
INSERT INTO "BMWMottorad".media VALUES (297, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5466jKcNpYJva0uXrxlNOz6ncXTVDT%25NYrDPrAbyBt0RfWsVXST4QaLiP171ysg0tu92wSHLfeHcI%25BNaABH7d0EQwl29Xi5WJryxug0ZOCDxS9qSaYJvh59rawWnul65J0073pQ', 52, false);
INSERT INTO "BMWMottorad".media VALUES (307, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7572nCHUfTCvNS9i6L55v09zdYPeVZEaYdvZHH3ai1Z4wawpGxZ84aiPZMgIaOGZHHIaOBrXspHaaGX99MiuTlELmOUuunL55DyU75YgxKfezhaaxUTCvGr5HqCrPdd9ap%25YxKfO', 55, false);
INSERT INTO "BMWMottorad".media VALUES (44, 10, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2743E0B9P3vBG73e12Gljw69E0IyJUwII0VAnqgXEwvCT%25J0b%25rtsevYuYEvYOlQrpi1GQc6rQwhNufuKLxVed2w4Z%25qk3S3B4fS%25wpYr9piwYwZ%258OmLyNFXjEePeSlVuj1VePz', 5, false);
INSERT INTO "BMWMottorad".media VALUES (46, 10, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4525Y0YaxQf0G0bKN1nl7O2HB7Ir85ftN0Otzy%25LEVVmXnb0Jgl1e4vEUj0fBOcolwz6G8y2cbvhIUwdmPxOsu6kCZzcVQgoBev%25SkOYWav%25kBwPgRv4PyI7TYB4PmGyk5F1Osxc', 5, false);
INSERT INTO "BMWMottorad".media VALUES (30, 6, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-52289l2CdLPqd9SY84UklgbwIH4C0VG8D6L4UkNla0z%25daBlhropzLSUf1U06P8LVYdbIZp4C0ErJfzKXq2B0CDz%25duVYLln1S7acBGubRPtz5jcrSz%25d%25QEpdiB6T9f0Ramz%25du', 1, false);
INSERT INTO "BMWMottorad".media VALUES (48, 11, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6422Wu2VAX7a9cYjKR985%25sKNMQCn4%25mQAB35QrrWPGx6unuhAffPnGrDtWZtYwZbxHKcZo84GPqeDSOzyHLjvR%25h1uQTXIY2hhdAPirfoEW%25rPcA0gZ2gmxvcHIund8L3lozTAa', 6, false);
INSERT INTO "BMWMottorad".media VALUES (50, 11, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6466WZQCBMiFVlwu3aJC01eNQuH7PH6CM3P53sgocDlzYRT7utHXSV925mqmoTAlDwvKjtp9YxpQ46cCVscpqflySjJKvu2kRi3oawAld0LPatvbtVMiFUkVBMxRNwJekillq%25BY', 6, false);
INSERT INTO "BMWMottorad".media VALUES (52, 12, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-77134JpnpM23bK117T8x8dB7wKXEUj5BTk2ZohmCKMHqkbdJqvngrdU47kCyp6%25WTy804cTLYacDj75%25HDoyt%25LUWf3xcMV2vqy8wrUsSTICUCWKv2uyO57MKd8BJ5RLchmharpo', 7, false);
INSERT INTO "BMWMottorad".media VALUES (54, 12, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3415uP4J0NEB3HOckaDbjab1mIdSgUaRqCnuKRgeusA0jCg0lqUjFkMcukumeG6AopQJ7ue5niws3A6QVfuV1Cy2B7CRkWyO4BbsIwd9Ug%25xycwDqwNEBWCpKExxqksbVxUctY0n', 7, false);
INSERT INTO "BMWMottorad".media VALUES (56, 12, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4835i1K66cfl4iTMrJ3McM9o4PJBbOqUpeeJ3MIknz1b6oJctZDBJgU7kQGze4VcWE495d5JBbFOuJ1Ni4TY5lp1b68WE1XZmoPoiYqSez4W9Y7vZT1b6527OD6xgGQcBBnw1b6m', 7, false);
INSERT INTO "BMWMottorad".media VALUES (57, 12, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-49676W5Q9Y%25WrN%25SV4yCrTvVdtDwxpPwKHnsqmNI1FhY5yPWB5RbBPX1waN0dnbFCEqptEmmfPYAOwx3XNcjiJCL7Uq4FY5SdBYWuBT6omgNLIEN5GX0HTpBIZqfWXrmBCA4TE9M', 7, false);
INSERT INTO "BMWMottorad".media VALUES (36, 6, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4568YUKr9qmIsEYyusoH1qAmmGKBVRrI3KJDR59fBLNkHRfttip7wL5Z38Fx48oWdzm6ydtm7vikADAyTCzgU9o2pa8uSISjDVF3BSW0knJ2aLgvi7IvdayzX7sKjZRuGEFR1V97', 2, false);
INSERT INTO "BMWMottorad".media VALUES (37, 6, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7224Fw5t3LbJA7czyYdto0Ih5LFsKF7tzaK7a1Cu0aZ3RUm8ziFRJM%25g7lj5umLZ2c6AQEU0C4r5NZPtMc0rTHGXJQdAlzgqUb2uXcB7jKDVgilHiMLbJidlD0XdScdIqf7GTo3k', 2, false);
INSERT INTO "BMWMottorad".media VALUES (71, 14, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3472uj8QGMjzw9R5OW33ztRHoIr0iy6JIozy88hJ5py7gJgnalyX7J5ry4dVJSay88VJSNmqYn8JJaqRR45bMD6WBSQbbuW33FeQ23IdlEG0HcJJlQMjzam37KHBrooRJnUIlEGo', 10, false);
INSERT INTO "BMWMottorad".media VALUES (58, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5737GL0Wg3bh%25nvs9cg1hfu1BilMDIwUMB8q%25I0TSmpknnKLRhdtkowzIFi4jRdRICzU0JNMr4CTUIvMQhFsDcykw%25G2s3XkYpKGPeviaHJEknKThOOfSpHsPnL0BbzAK5zMwOgz', 8, false);
INSERT INTO "BMWMottorad".media VALUES (59, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5554MGDDx6SLoymr8tDCx5sysdNgZ6H4dDxI4eEecJIiP4XZW260necIIVr8eTWI4e8eT5O2%25hsmsq2KDfcmNvHtzTKsKltDCGVC9KdlAGxnr1ms2C6SLrVs4qSsNC4sChr5AGxK', 8, false);
INSERT INTO "BMWMottorad".media VALUES (60, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5770GnzyFK8ShG4O5UXNn3UlSiU2scQ5unoUXNxjz8owFLKn4X1aVVbgrGg8n86K13hUhm2U2sRYHrocOFBowyuowFP13KTeGfQLZoQ%25ty8XonJ7X4owF8dJYSS%25jkZt8yzdowF2', 8, false);
INSERT INTO "BMWMottorad".media VALUES (61, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2335sxHXXicg9sOSGAISiSEN9fAJ1qz7luuAISLMDex1XNAiZpdJAm7RM2Ceu9Wi%2589EYBYAJ1oqFAxPs9OQYglx1Xt%258xvpaNfNsQzKue9%25EQRypOx1XYTRqeXUmC2iJJDrx1Xs', 8, false);
INSERT INTO "BMWMottorad".media VALUES (62, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6931xi02jRCzgT4CM5GaSOWM0PuMwMVydEsUi5ZXZQVo7SkiRYANbkOLr0hRYeIoub%25cXJaHWp8PrrO2kLG8stUfbYG9RRBDFRQgBbpT2aKhfXRTYepRBkWJxZ%25FifGH3dTUw8jL', 8, false);
INSERT INTO "BMWMottorad".media VALUES (1, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6311BNfM11CWV7P2UbsdrtAopn3SvpI2VOo8CuNRYSak6spW5zCzf%25cXws7%25pof2dEpIUMAQzpYQN8uWgOgjM9p5OtC5F9zhpfXDEBtBKxJWlPE3zZ9pNrq7RaRJ7gKuB%25EfUv1s', 3, false);
INSERT INTO "BMWMottorad".media VALUES (42, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4652qqyf9SFrNcnhCKAblEmpyyCRzpY4sqBeIoAHM0YXu6GqSNRmTZErkylFW78gRj2DNGbmQSBaekEfZUuBLkejTHA3FStilh0NtjFcbfY6jWF9NGFhU7mFdOPldTAQEwceBL9K', 4, false);
INSERT INTO "BMWMottorad".media VALUES (39, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3820JxlGLhU%25c3vx0NUFnLXIrDAsWWXXWMtIHjh63s0lx9liBsHmW4GkqubKl1lP7orLYiZ1mrQIZIYzCqDoGBc7qXdFQFDVylVUo3ZoUO6zGfRNsVFrPg%25JN7bMQe5YQK8rjWLH', 4, false);
INSERT INTO "BMWMottorad".media VALUES (41, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3217CPaLXSynHeVS%25tAzziEIawIR6qgByd51InxWmCX1x6N%25hOdQtDEoc24sHHyg%25oa777BAQ2byY1xLDUvbBgcTtZAG8hVv52pNKoSe549zj38cOOh2T7x8qGR5CKAiQ8ecL6XQ', 4, false);
INSERT INTO "BMWMottorad".media VALUES (269, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-291239gXW8IyBR7f%25fgxWsPC%25vkr9wehQgHvSTNnoTQNMSUckCwu6jVmvLbPn5eQhj0TlsYpMd0GPmRLYho7J7Jb2lzPBw4Yi1ziVBm8OcH5fK7%25CE8IyW0m6Zg%25eESPEIb831WT', 48, false);
INSERT INTO "BMWMottorad".media VALUES (279, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4361H99eNFPald7zRbcvHhRCduJVYsX8Q9ZQyVWtUTxGAyj9YqwQznTum55PULkEwTqolFkRv0PNRmP4g2tZgDJLS6lpLFlYugLMrLxaOeZlLUZIqEh%252ORQ43cW1iypxC58ZgNr', 49, false);
INSERT INTO "BMWMottorad".media VALUES (288, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3833JrjT1pAIhQgsi8jZ1RxvEOo5URoPDj930L9BbBO1N05tKmRN2z4D3S8EBaVOPzxL2RjQHuiYxOvhn%25bgVYKwI2FxSCsn7th7fS3RJU9ys4gEmGpAIsFz0YGEKG0xGM8Ckt1Y', 51, false);
INSERT INTO "BMWMottorad".media VALUES (85, 15, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4418wcSGtoM1BkipB8%25i64Gfi4JqNQm%254g6RiG9iV0Rr2%25A1w8QayiVoRPkEi6wRiGEi6DZ3yAnGgp3gnXVz3Tm8c6iS%25V8%25iyTgDS4wbWtcwQGg8goM1fxgrcnkJnzGSAOsbWtZ', 55, false);
INSERT INTO "BMWMottorad".media VALUES (298, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4363Hjb8SrFSwHbHfrJ3nNo58ArFScAbAonrJ3xo5wrFSbnn5cchjo5crD9woS5rJ3woSAsrFSRJ3UrJ3s5oysArFSRJ3UrJ3BmbNoAdrFSYUrJ3cbrFSaCRJCGRrJ3o8S5IrFSD', 52, false);
INSERT INTO "BMWMottorad".media VALUES (308, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-52429LsR0600R9wcw5KJB9b2CN5%25%25UH8W4z5KJG4aC600szByrU0Bfyr5kUC4%2526okRb0HC5%25%25vKJ66okpafICW600mokllVeF3s1fHu5%25%25TllVerw600qmvKmPklVebpPaM600k', 55, false);
INSERT INTO "BMWMottorad".media VALUES (72, 14, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6750I8jD8m0VEAAD3Bxok4V70aF6GX4whFX0X83GIlpSJhGwVag1zWRWPZIq7xTCJa0OmROj1%255zv0VCcjd938LfnQh8Hv5AjntL25sNgHhpbW5ia6v%25oQs9yoBU2WLo9I1ZkG8P', 10, false);
INSERT INTO "BMWMottorad".media VALUES (73, 14, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5071DxaTxgWS9eknnI1Sz%25FtHvARtl%25EMu5N6iTrDCZALAtihv5bIK7oWtDDU9yGzQHjY7j2bNRqYNhZ4aObjiqP2XAioXpka2wImRiK5KuG0oRcvpXNhYxbvSIsmKISb34rLtxb', 10, false);
INSERT INTO "BMWMottorad".media VALUES (74, 14, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-701857bQgc0GVHRaVl8RntQURtWFiqI8t3nyRQZR9wyYz8%25G5lqLBR9cysHpRn5yRQpRnAmMB%25JQ3aM3JD9oMeIl7nRb89l8RBe3Abt5rEg75qQ3l3c0GUC3Ys57WJoQb%25u6rEgi', 10, false);
INSERT INTO "BMWMottorad".media VALUES (75, 14, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-52329CgwmvzRGd5VDgj43O8GzW%25UhBfo7%257nBsCLutoxejLRJcL9X6mAjjd6z7YV4yzbOs8S9LMhRn8pA%25MWsmBJPDBerQcUzXu0acO9ZyERe6yPcdQLCDfqAKgqdA7sc5aY3hmS', 10, false);
INSERT INTO "BMWMottorad".media VALUES (86, 16, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3471upBkpDi47HWeehZ4KsbXEqP2XnsR%250jxTCkguavPVPXCfqjth9Q1iXuuY7zmKIEJ3QJLtx2S3xfvUBMtJCSwLOPC1OyWBLlhd2C9j90m812GqyOxf3pI1Hv7d9h4tAUgVXpL', 13, false);
INSERT INTO "BMWMottorad".media VALUES (87, 16, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3752yylVHzBcAWgLseIor0Cwlls8nw7K4yjD2JIuqF7ZdtiyzA8CXx0cOlrBMEbG8Y6mAioCRzj5DO0Vx9djTODYXuIQBz1%25rLFA1YBWoV7tYMBHAiBL9ECEfllqaXIR0fWDjTHt', 13, false);
INSERT INTO "BMWMottorad".media VALUES (88, 16, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-294130Uijz9hHQR%25Fu1BXnZa9mdbMAGZAd1aAYBrQfhr0NrPT4MRMVEO2IokUNtSEe9TG0xHRcCyxaZnwameEjNxy72BCLmJ5rJ1JmiJcmtTEVsM4JLcF7S4RbY9ROt7CJb1XMjR', 13, false);
INSERT INTO "BMWMottorad".media VALUES (89, 16, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3773y25VWBB1MWXzskqotPC85lwwn8ZKfajOyJdAqSZZqri2BAsRXEPc35rzuE478glmuEoppzn6D3PVE1dnnOOXXMqQzB1PULSM1gLWKK7UXMzNAxLLcxCi4l6daYqR%254WOTTW1', 13, false);
INSERT INTO "BMWMottorad".media VALUES (90, 16, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-1723khAYTY2%25AfO0TtrT%25FGt232O9M0zW2qAMxx5pDiULl5SiRufU4PsMqOs6MMExQ2zETgNfaQ5zAG7DIRRXTqndxcPRgoVtufcvo7OdJrGT4b5RkgaPxYRpkhtwsyZbwwW%259TQ', 13, false);
INSERT INTO "BMWMottorad".media VALUES (91, 17, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6413WdtvtLYaHM00sQ9b9nDs1MR4imGDQIY8uJlrMLSTIHndT6vpxniWsIrXt7VhQX9KWPQ3CgPymsGVSyuXEV3ihNabPLAY6TX91xickQjrirhM6YzX2smUqq0ddGU3PJlJgxtu', 14, false);
INSERT INTO "BMWMottorad".media VALUES (92, 17, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5756GUb2aUw28GBHlKkWtHU48xKh8Ju5QoKKkWuKzhr8afotlXkhoT6YoOghosbUcG8UyAaKh8%25eHKr1Z8Ln2yQr8apcGrTY3bEfGnu%25VFs1tjgDXBr8aXNNDSYCnXOrShzRr8ak', 14, false);
INSERT INTO "BMWMottorad".media VALUES (93, 17, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-65608cFZtVA1LJiCz80x6bZfEfJdHQQP4Y5REZ9Eo0pt20u1ssQ22iKKR%25JEE5wpxGxx6373aun7XpOXngozOjmw16Eh%25Ks%25E2TYOSb8bHUcsmGYsgVA1HY608znenBZSM3sfNta', 14, false);
INSERT INTO "BMWMottorad".media VALUES (94, 18, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3825JRJFvAlRDR6UZXKz3Wh7b3Pn2BlTZRWT4SCfQrrukK6R1ezX95MQjoRlbWgtzy4LD2Shg6MwPjy0upvWaELcdO4grAetb9MCscWJGFMCcbypeIM5pSP3VJbepuDScB8XWavK', 15, false);
INSERT INTO "BMWMottorad".media VALUES (95, 19, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-1918riKCZNSxJMslJt4sX9Ccs9AzP2a49mX6sCEsWb6GT4hxrt2jnsWN6fM8sXr6sC8sXdpInhDCmlImDvWeIOatiXsK4Wt4snOmdK9r1%25Zir2CmtmNSxcslkCDOADeCKhqU1%25Z4', 16, false);
INSERT INTO "BMWMottorad".media VALUES (96, 19, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6673gX7MS33PzSpD9qnAxVU17Gccm1wuWYQygIjLnewwni4X3L9tpbV%2527iDBbH81CG5BbArrDmZa2VMbPjmmyyppzn6D3PVEOezPCOSuu8EpzDhLfOO%25fty0dfiYRntKHSyvvSi', 16, false);
INSERT INTO "BMWMottorad".media VALUES (97, 19, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3462uwYpkKG4Edys4PZKDeQL7qhtP%25mQ%25F7LPDVgdUfXwxXskr02P9RAzh9HYEg4CN7JQ8Rx2Z2zRLvk5BqNReipLvLK2VqWjXWZHICH7dYeR16%25rWVZfQ4BT3lSauXm2NUGOPk2', 16, false);
INSERT INTO "BMWMottorad".media VALUES (98, 19, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7532nMVIWNwukiS6cV4y91dkwXvzRs25evefsqM8GB53r48uUT8noFW744iFweK6yPwa1qdpn8ZRufdA7vZXqWsUQcsrLHTzwoGm%25T1nJPDurFPQTiH8McybedG3i7eqTS%25K9RWP', 16, false);
INSERT INTO "BMWMottorad".media VALUES (99, 19, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6961xZZNifsLjhvoyr7dx4y2hPW9O6DlqZmqB9EgXeCQ%25BkZOF5qoJePITTsXKHp5eFcjfHydwsiyIst3zgm3AWKbnjaKfjOP3K0YKCLuNmjKXmSFp48zKUqZcOFGRBaC2Tlm3ig', 16, false);
INSERT INTO "BMWMottorad".media VALUES (76, 15, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-29163bR7kNl8CoAaXXeg8lxYbQLiN0yTxbyPC%25CV8Mq9VKtbIs%25T9Uyb08Qloq%25I%25q4TC1Gxn6qVT0MEuwwyHYhcapDSyNe1JdrDCcMQS7cmcorVsNW5wqZcXA3Uf54irBbxyHk4', 11, false);
INSERT INTO "BMWMottorad".media VALUES (77, 15, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5029DE2TEYWh1eJjndcSL0FUNvupt60EAA5HlijUDpGABMtxSvlfIVZoNrDOt927zmNjgZjafNCdYHSZf2O4TiI%252YMiKgpJ228qmCEKlouZPoC9vRgNFXx4mHFjmVqS4O4tztEW', 11, false);
INSERT INTO "BMWMottorad".media VALUES (78, 15, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7132OhNBP0tSAwVYxNcTiEzAtQ2k5rjgM2M1rLhUpegdZcUSG3UOHKPCccwKtMWYTbtnELz6OUR5S1zFC2RQLPrGaxrZJ%253ktHpyf3EOubqSZKba3w%25Uhxj8CyxjwCML3VfWi5PO', 11, false);
INSERT INTO "BMWMottorad".media VALUES (79, 15, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6144Up7VfK%25m7acm4LL4mCJL0cP1TGm8g0EZZDOSu9OLwhhCOM72LaQIGx9dF7GDDN083boX2PNS8Zkk9EMAo4ifxOTmAVllBZyTH6e9EUBeb22SMrVPv3V6lYVsddPe2IdgvTfH', 11, false);
INSERT INTO "BMWMottorad".media VALUES (80, 15, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5053DhHLP%25rSusVgiN1niiBAUv2J6rnYMau1tzhrCeXIZ1tSZOU3NK0Rc1sKUuWgnbUjEBB63tRlF1LhCapQB%25rZ2xtGJPOkUNp243iDu4dS7obyOwPthET8paxnsCAz3o4Wx6P5', 11, false);
INSERT INTO "BMWMottorad".media VALUES (81, 15, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4432wX27TjAg6kv0L2qxzBG6Ab1pHME%25l1lIMZXuVC%25UhqugS8uwamTKqqkmAly0x3AiBZGNwuoHgIGYK1obZTMS9LMhRn8pAaVcO8Bw53rghm398knuXLEJKcVYkKlZ8vOyzHTq', 12, false);
INSERT INTO "BMWMottorad".media VALUES (270, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4565Y2vct1sqvBZIUoKUq2NowG8GkvI6OwRQmuAb0GuV64fyu%25mzVzqhvC7SfQvAuEw6ur13zwEb6QHWGp%250cUpUpAed09nTVvLeEjN7CXoWrLBb%25X9wIzlm%2527vFSsHBSFOdktm', 48, false);
INSERT INTO "BMWMottorad".media VALUES (280, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6114Us%25vmwiQiUdVCSBK8V8%25icSuxBkRYSFSBKehdA8xm0h8RlLuh2C6Fj5ASE0w4ri8veQSuxWLoS8ftiqymmY8xm74r8y5nP90UykHhMEbs2lTld8xm5VhU3VTa6jsMud78xmm', 49, false);
INSERT INTO "BMWMottorad".media VALUES (299, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6459WOxRfQxsTlyQOhgpCJeZxAZW0GbCiZ%25LGwkjcH4Bk%25jDmt7cFUkaziquTnibO2xKoVCXcEIE4LeRUh1IpfzsFVgVAm2cPEWny2Ql0IzCwUABtrmEwVJA7Vl0Wagk1MlzC0fn', 54, false);
INSERT INTO "BMWMottorad".media VALUES (119, 7, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-70515xebF6E7JdVWwas87uo2mtunz9HRrmG9eJgCHK1F0C%25EcW90FpWM9OUmCg11JkQRYa4U%25ikCR1toVOHO6sW27Y43OlywsYR41wUUHzSTyqpCWf6E7KCLpjASMvmopxurNBFK', 20, false);
INSERT INTO "BMWMottorad".media VALUES (120, 7, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-65618RR0w1rJDo2HTZCz8cTjobPiIYqXLRyLeisvQMlafeARIKgLHuMbB33rQW%256gMKxD1%25TztrwTBr7dkvydFPW9ODnW1DIbdW4mWlJS0yDWQyVK6cUkeTpRNj0p5enlj3Xydwz', 20, false);
INSERT INTO "BMWMottorad".media VALUES (121, 7, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3861JoojkIMRsQ1axhKGJqxEQ3Tzt0rPZocZCzefblW9OC6otm%25Za5l3788MbynN%25lmLsInxGAMkx7MFUpfcUYTydwsiyIst3UyD4yWRgjcsybcvmNqupCxVo2EjVHCiWE8PcUkL', 20, false);
INSERT INTO "BMWMottorad".media VALUES (135, 8, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5634bJRjpAy34o19ZTsi8qL78oXitjlLTJyZKSmpoMWdk4IJImnXUdrb7JRyRl%25NnysP41nLg2cOT7l0HOVyU0LrHfDicAK2Qdyssrr8SjqCrRWVm2MaOlZlPJ1bk5CzcFQhyUpC', 22, false);
INSERT INTO "BMWMottorad".media VALUES (136, 8, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3550fTN0TF6G2ww0P1yZiYGI6otkdMYnrtM6MTPdfezUxrdnGouv9CLClqf4IyWBxo6%25FL%25Nv5J9S6GBmNbQPTcgHhrTRSJwNHOcVJjpuRrzXCJaokS5ZhjQKvO6VCcZQfvqidTv', 22, false);
INSERT INTO "BMWMottorad".media VALUES (130, 9, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5438jtkWI1eMw0x1UQ4HW66okgonOVINkV3RKu68Bndp6Dwr9SKzvSlxpe7gw8kIUEk2ayNbzk7JIR5WSvz7Wdpuv24aY9iLOkTsEE10DZRWMhYRSh9kAylY0u1xji45Bg0pHOID', 21, false);
INSERT INTO "BMWMottorad".media VALUES (131, 9, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2656VSdEiSAEuVCnPy6TFnSquJyQu5g%259ayy6TgypQhuiIaFPb6Qa804atfQaMdSLVuSxYiyQuOlnyhBouRwEx9huiNLVh84UdeIVwgO2mMBFsfrbChuiE7OvTimwbthvQpHhuiQ', 21, false);
INSERT INTO "BMWMottorad".media VALUES (132, 9, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-70375M14aLxW9dn78sawWiowAUmKBkGRKAZe9k1qHjgSdd0MXWJpSPGukNUEIXJXkYuR1hfKCEYqRknKTWN7BsDSG95O7LyS2g05cFnU3bhtSd0qWzziHgbFweM3AxuV0QuKGzak', 21, false);
INSERT INTO "BMWMottorad".media VALUES (133, 9, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7961addC2YT9WUFGo3qfaXoKU5Rv0ePJbdhbcvyAuxLS6cEd0rkbGix54HHTuZpBkxrQWYpofjT2o4TD%251Ah%25sRZgNWVZYW05%25ZlMZL9wChWZuhtrBXn1Z3x8mUeIzcVLKHJh%252A', 21, false);
INSERT INTO "BMWMottorad".media VALUES (134, 9, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7642AgofLcLLfAKuK13vXAkrbq1BBNIVdJY13v0JtbcLLoYXUHNLXeUH1mNbJBrcOmfkLIb1BBs3vccOm4telbdcLL8Om99DQTpoMeI21BBG99DQHKcLL58sBQzB9DQk4ztacLLQ', 21, false);
INSERT INTO "BMWMottorad".media VALUES (137, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7122Om8TQ1Hsek9Un0eF4qSn3vE%25rzqiEQ574EVVOIWAbmrm2QLLIrWVGoONo9hNBADnkNjFzWIpgGyZlwD6Ux0q2JmEt1R9822CQIMVLjuOqVIkQdcN8ci6xkaRmrCF67fjltQs', 23, false);
INSERT INTO "BMWMottorad".media VALUES (138, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3439uzvohaYLC5eNpAOJPqoqkI6Zn1c3df%25NkoBka3HFxOgLAM1iEe2yN35Jk%25MHJKeJPrKtxgsVbWUbsbaCUs9uBPkQD2MDkEwftmquITSzAcKfM4aYLIe4haCwlspomYUudjhf', 23, false);
INSERT INTO "BMWMottorad".media VALUES (139, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5442jwdAQhQQAjqnqF5t8j2PuXFmmBYIgasF5tea0uhQQds8%25zBQ8y%25zFrBuamPh6rA2QYuFmmW5thh6rM0yxughQQH6rSSlUR1dTyY7FmmfSSlUzqhQQiHWmFlHSlU2Mv0GhQQm', 23, false);
INSERT INTO "BMWMottorad".media VALUES (143, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7167Os3LRIUsmwU9i7ejmMziovFglnrgE8uYKBwVp1cI3ersN3TZNrqpgJwtouZ1j6Knv6BBGrIfSglhqwCA5PjW2QK71I39oNIsbNMOxBdwWV6w3aqt8MnNVSKGsqmBNjf7M6Re', 26, false);
INSERT INTO "BMWMottorad".media VALUES (144, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7156On5FSn2FaO4GLr1ZjGnlaQr8a9izuUrr1Zirf8TaS6UjLJ18UoBeUNk8Uy5nXOanhESr8apcGrTY3abVFhuTaSIXOToeH5m6OViptsyYjKkWJ4TaSF0kcgSOVJNTw8fdTaS1', 26, false);
INSERT INTO "BMWMottorad".media VALUES (145, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2570dH9Kt7TUrdY%25J3MpHP3eUa3VjmhJ8HZ3MpyN9TZntc7HYMvoGGXuDduTHTk7vPr3rFV3VjLARDZm%25t1ZnK8ZntlvP7WEdghcqZh5OKTMZHxIMYZntTbxAQUpNiqOTK9bZntV', 26, false);
INSERT INTO "BMWMottorad".media VALUES (146, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4054tLffjuZECNVIDdfkjMONOc5hBulvcfj9vwnw2s9TYvFB6HugPw299RIDw069vwDw0MbHX7OVO1HpfQ2V5oldx0pOpAdfkLRkypcAULjPIaVOHkuZEv3ENVZx5kvOk7IMULjV', 27, false);
INSERT INTO "BMWMottorad".media VALUES (141, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6447WeYJDsP8BqH4pzXv3sC%250AgtYFesEYGihVDnrtv7mhjJkIhABtouELlIjzYmwr0Kf8e%25A0qGCipb1FtWJOYfF4Lplw69EY5xrlmyZ9GbbUW%25Iuw0sbbrWyzacAhpMIlFOYDL', 25, false);
INSERT INTO "BMWMottorad".media VALUES (142, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3272C9B0Mp9rLDFKxvEErJFmY8kaqfo78YrfBB67KhfuW7Wc4VfNu7KkfnsX7l4fBBX7lQ%25wHcB774wFFnKjpiovUl0jjCvEE5G0bE8sVdMamO77V0p9r4%25EuCmUkYYF7ce8VdMH', 25, false);
INSERT INTO "BMWMottorad".media VALUES (140, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-362375CW9W42CjEy9eJ92lAe4i4EORytQ48CRddVFxIkUoV6ISpjkTaLR8ELKRRqd%254tq9Nmjf%25VtCAMxsSSH981wd3aSNgYepj30gMEwGJA9TnVS7NfamVyAd5eBLbunBBQ2O9b', 24, false);
INSERT INTO "BMWMottorad".media VALUES (105, 5, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3059SyftW6f9vGg6ykCrUIdwfLwSosNU4wKOscqQ%25FH3qKQa5x8%25JEqYD4nBvm4NyXfuAMUp%25bTbHOdtEkPTrWD9JMCML5X%25VbSmgX6GoTDUcEL3xi5bcMIL7cG8SYCqPzGDUoWq', 17, false);
INSERT INTO "BMWMottorad".media VALUES (106, 5, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6450WvhovJZsXccoVPgw4RsTZAxqjzRmixzZzvVjWdDEfijmsABl0UOUGnWHTgS3fAZKJOKhl7I0eZs35hN6Vv%25CFkivteIchFy%25MIQrBtiDpUIYAqe7wkQ6uvy7MU%25w6Wln4jvW', 17, false);
INSERT INTO "BMWMottorad".media VALUES (107, 5, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3373TjgNPeeEhPQkrALH7blUgXttOURW1nDITuzFLVRRLZwjeFr5QsbxdgZkSscCUvXySsH66kOYqdbNsEzOOIIQQhLakeEbGJVhEvJPWWCGQhk0F8JJx8lkdARTnmL5fcPI33PF', 17, false);
INSERT INTO "BMWMottorad".media VALUES (271, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4421wA7g9vc9XwZs7m0Su8i3Y4m91CbGfEAm0SlEOgvc97AuDRC1MxDRmSpgE13v%25hXi9bXm91T0SQv%25hgOxkXfvc9j%25hmQPFWB7sxbVm91ImQPFRZvc9dhQynFjQPFiXcOVvc9e', 48, false);
INSERT INTO "BMWMottorad".media VALUES (281, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7449ROejKHrVVRcqXGv%25OIZXK8GTtx2XSDWGv%2583JUNUKkNO9mEjHN1QZCQUDrYHidVZoanGTt5QPZNEIokHrjSNUKfidHDMC9akCH2b7nrQN3uRmcNUKxPG%25LRpOApGUnJzNUKx', 49, false);
INSERT INTO "BMWMottorad".media VALUES (290, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-701351qKqihN6UXX3V2v20b3yUkQjoBbVchOtwudUi7%25c601%25MKen0j53cdSqLCGVS2R5gVfJFgHo3BC7HtSTCfjGlNvgirhM%25S2ynjasVPdjdGUMhESWB3zUKPc1BIfgwuwFnqI', 51, false);
INSERT INTO "BMWMottorad".media VALUES (300, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4643qyrOai0rAMiZD4AocBKOqysbGkBssyYC18NHqB0h92Gyn2JeLZ0WpWq0WEo%25JFIDA%253KJ%25B5mpjpXUdYZw4BTu287i6irTj62BFWJOFIBWBu2zEPUEsY9Vn6aZ6oYpcDYZaI', 54, false);
INSERT INTO "BMWMottorad".media VALUES (161, 21, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3559fLtYxjtGIvOjLNyXgFS6to6f9lEgr6cAlZhdw4iuhcdznR5wHChDMrkKIqrEL3t%250Pg2wUJUiASYCN8JXxMGHPyPon3w1UfqO3jv9JMgZCouRpnUZPhuWGt9fDyh8VvMg9xq', 31, false);
INSERT INTO "BMWMottorad".media VALUES (162, 21, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5743GiSrEe3SXgeVUdX2zRarGiuIKlRuuibHLATjGR3vBxKisx65pV3nWnG3nJ2D6QZUXDta6DR09W8WfF7bVMdRwYxAoePeSw8PxRQn6rQZRnRYxCJOFJAHGuWPEVP2bWzUbVEZ', 31, false);
INSERT INTO "BMWMottorad".media VALUES (163, 22, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5458jPGUzKpxZFkv6lLlxR16%25Yq1oNQ2c%25vWZW7FEe34Sh8PDiHa48Q0NiYCSOHDWDP274rc2RDF2NJ9JExmV5MbmGTMmKzfzDsTG4JYurfYbFsFiVoCi22WMFvMPRPcsq0cQKzP', 32, false);
INSERT INTO "BMWMottorad".media VALUES (164, 22, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6913xSYIYoDziPssldGUGkMl7ParpqvMdFD5%25HTXPofJFikSJjI2RkpxlFX3Ym1bd3Gcx8duyO8Lqlv1fL%253C1upbEzU8o0DjJ3G7RpZNdeXpXbPjDV3Blq5ahe5Svgu8HTHORYg', 32, false);
INSERT INTO "BMWMottorad".media VALUES (165, 22, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7439RU%25XlbNrFo7vSpiZysXsGwVM9ODx8navGXtGbxQ6qiHrpCOdI7f4vxoZGaCQZY7ZyeYkqHBgTmJTBTbFJB3RtyGPEfCEGIznk0sRwc5UpDYnCjbNrcjmARYrKBSX0NJR81lq', 32, false);
INSERT INTO "BMWMottorad".media VALUES (166, 22, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-52649WI4HTXqUUnBbmUpyiRf1HDmBwi3DNheaO6l9EgGaHBWPW8wiLg5k69Y6TRXw79btXfCsYEMok%25ehq1FBDmi%25UHOBTMnI%250uWEG58bZ1i5ErWingdmoebanRNLupFJa4SzHW', 32, false);
INSERT INTO "BMWMottorad".media VALUES (167, 22, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-1970ryqvuSEMAr%25TCs6oyjspMcsQifYCeyFs6o1aqEFxuISy%256bmhh0lwrlEyERSbjAsAgQsQi75KwFfTudFxveFxuNbjS2zrPYItFYW8vE6FyBU6%25FxubKsVMGvaLt8EvqDFxut', 32, false);
INSERT INTO "BMWMottorad".media VALUES (151, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3261CmmiRU6Kk4dcBYvhCtBz4sEZunAjFmIFVZp3DN2q8VHmufTFcWNsSee6D1xaTNf7kUxBh56RBS6gMo3IM%25E1rJkL1UkusM1wO12KPiIk1DIbfatlo1YNo%25yrQyVL2zejIMRp', 28, false);
INSERT INTO "BMWMottorad".media VALUES (152, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7421RHgTr3trjRYpgOiPWCZenwOrUvsX8GHOiP2GJT3trgHWkmvUN7kmOPQTGUe3x0jZrsjOrUBiPD3x0TJ7oj83trzx0ODE%251Sgp7sbOrUuODE%25mY3trVBBiBzVDE%25ZjtJb3tri', 28, false);
INSERT INTO "BMWMottorad".media VALUES (153, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2373swbnD66kmDc5FgCTVq0hb4SSUhWjz8tGsXRvCaWWCKuw6vFPcAqeZbK5QABNh94EQAT%25%255Uf7ZqnAkRUUGGccmCx56kqolamk9lDjjNocm5OvMlleM05wi2981CPdBDGrrD%25', 28, false);
INSERT INTO "BMWMottorad".media VALUES (154, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6059PI851a8r3XTaIov6luMR8FRP4p9lwRfJptADx%25ceAfDqy7CxKGAnkwLS3Ow9Ij8WHNlQxsBscJM5GoEB61krKNvNFyjxbsPOTjaX4BkltGFe7ZystNuFghPCPnvAEhXkl41O', 29, false);
INSERT INTO "BMWMottorad".media VALUES (147, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6658gFxcTk80Ez3RUtjt0sHUhG2HeuC5NhRAEAiz%25OmVLB4FvPMlV4CSuPGwLQMvAvF5iV1N5svz5uDWD%250pJrIKpxYIpkToTvfYxVDGq1oGKzfzPJewP75FOaFIFsFNf2SNCkT7', 27, false);
INSERT INTO "BMWMottorad".media VALUES (148, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3021SvN9JieJcSWFNEIaQhuZ1BEJk0LHzAvEIa4AG9ieJNvQ7P0kmM7PEa%259AkZidycuJLcEJkrIaxidy9GMgczieJtdyExq2D6NFMLnEJkpExq2PWieJty8EUkJxq2uceGnieJJ', 27, false);
INSERT INTO "BMWMottorad".media VALUES (149, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4549YLSd%254pPPYwk2lTcLJ62%257lIRt32WzflTc7BFCbC%25hbLsnUd4b8j6gjCzpa4reP60DqlIRmj16bUJ0h4pdWbC%25xre4zVgsDhg43E5qpjbBKYnwbC%25x1X4APqLoXlCqFMbC%259', 27, false);
INSERT INTO "BMWMottorad".media VALUES (150, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4436wlgi6Ry10p%25vEo%25gNKgvS4brA3Kz4zN8Gzuiwj8lNzA6kb3HriwQ8xwFiIk8GzFiIsxJW2nn%25wJSGXwGQLKocIzzipo%25gcXn4n4v3M6yVQn%25bnRy1iPtkgycbingG2Om3M6L', 27, false);
INSERT INTO "BMWMottorad".media VALUES (155, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3814JBa%250zdPdJ8gF5tYLgLadD5RqtGhN565tY7l8pLq02lLhKrRlfFV61op5I2zjedL%257P5RqmrX5Lnkds400NLq0AjeL4o9y32J4GQlCITBfKcK8Lq00impbQcbV1BCR8ALq0t', 29, false);
INSERT INTO "BMWMottorad".media VALUES (156, 2, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2012QHGZMb2lj8EVSVGPM4hsSpOcHfDLRGupzXAgJXRAqz9WOsfdtYkCpTohgUDRLYFXr47wqaFihC8T7LJE3E3o6rnhjfK7%25Nn%25kjCbvWuUVeESs0b2lVjYMb0xD0zh02obQNMq', 29, false);
INSERT INTO "BMWMottorad".media VALUES (171, 23, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-1912rLb4jMGEpWVd3dbejADN395FLu6mcbT9Qsn8yscnYQhB5NuX%25wa19CqD8P6cmwOs0AfHYZOoD1WCfmyVlVlqi0RDpuIfJzRJap1MUBTPd2V3NkMGEjO1%25CZb6kQDkGqMrzjo', 33, false);
INSERT INTO "BMWMottorad".media VALUES (172, 23, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2345saBjWf5cxDY4hk0jrR0sBbwarw3jbFrOFYIEChOHqjMy4vwI9ECkOzKLEM4OFYLEMQnpdljB7DpjEgCjVG3k9M0EB4k0j5SEJYbDVUWUevB7vEf5c5GDlj50wY000lD3VUWj', 33, false);
INSERT INTO "BMWMottorad".media VALUES (173, 23, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5157hb9M4PweIPIiundcDjcEazzKQGjlL53SHlvuhrhfD5Q4gBG3VASESMhyuRYhW62MCFAgD8tUqFXyNchNx6TTkC5lA%25jI9k9UztBxGmb8nEtdBtPweKIFvy8dBAUcNwZxZv4D', 33, false);
INSERT INTO "BMWMottorad".media VALUES (175, 23, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4037tdWo6n%25uN2Yxfb64u0k4q1RJTDEwJqi3NDWaAX7B22hdGuOsBSEIDM1PyGOGDZIwWzKJ8PZawDYJguMxTbQBENtmxn5Bl7htHLY1vVzcB2haujj0A8w3vkdlq%25IehpIJEj6D', 33, false);
INSERT INTO "BMWMottorad".media VALUES (176, 23, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7319ctUVc0EIyMXSmwr31PmQuWVfnRTCOUYOqb96lzZXWqztjAC3hBLW3ayi5FK7RzM4a0ovOii1m3xwjI5gnkVhPyyQS02THTSW6SZqeKYahlgAAZPxqkmOssAUU7qQGmypXTc6', 33, false);
INSERT INTO "BMWMottorad".media VALUES (177, 25, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6051Pe6qv%25kVlZajuxAMVXyi1SX8RLTWF1oL6lbNT2zvON3kBjLOvHjYLUh1Nbzzl5cWfxIh3J5NWzSyaUTU%25AjiVfIrU0EuAfWIzuhhTRQsE7HNjd%25kVBIuQ1y7Y91yHeXFnpv1', 34, false);
INSERT INTO "BMWMottorad".media VALUES (178, 25, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3465uohv3Qnfh9IbD7GDfoR7TqjqxhbJPTBFSs8Y5qsZJgXVslScZcfthzdrXFh8saTJsOQ0cTaYJFCpqLl5vDLDL8i45mWNZh1iaHRdzA7pO19YlAmTbwvHHKdJUrnC9rUP4x3%25', 34, false);
INSERT INTO "BMWMottorad".media VALUES (179, 25, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6313BX%25U%25mwZLjkkNrhMhR6NSjcAotb6rgwWTyE0jm3CgLRXCiU9KRoBNg0s%25fdDrshIBerl18e7tNbd37TsVdloDzZMemnwiCshSKoFarp0o0DjiwQsGbN4dU3pXbPleyEy8K%251', 34, false);
INSERT INTO "BMWMottorad".media VALUES (180, 25, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5748Gptuoze8Wiq02E15JTHh1E0bvEZHiIkFA94ti5SKRNVRjLEpmrEZFdn9tOTSuccU3PM7Rkq2uhGUyaicirGis325qBxc6K11YMxgYQVVETyALcze87yWoM2jPWtHqezggmoe', 34, false);
INSERT INTO "BMWMottorad".media VALUES (272, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2436XOql3jkRUTrL5Erq8iqLcG7vbFiWGW8YyW4lXuYO8Wb3P7FsvlXBY6X9loPYyW9log60wJMMrX0cyIXyBNiEpoWWlTErqpIMGMGLFf3kxBMr7MjkRvtXbq2M7lMqyJhzFf3k', 48, false);
INSERT INTO "BMWMottorad".media VALUES (190, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5051D6%257935a0KxwXegYa4EJzQ4MWCsjvzyC%250qnsiR9Unr5pwCU9TwfChmznqRR0PBjdeGmrlPnjRQExhsh3gwJadGFhOkXgdjGRXmmsWcAkVTnwZ35apGXc%25u%25fLzET64v8H9z', 37, false);
INSERT INTO "BMWMottorad".media VALUES (191, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5573MAdwr006crL%25mfW82ZDQdqvvSQTspuFVMbH1WiTTWygA01m3LYZlody%259YCjQzqe9Y8OO%25SIKoZwY6HSSVVLLcWJ%2506ZaPic6zPrssjaLc%25t1XPPlXD%25of9auBW3GCrVhhry', 37, false);
INSERT INTO "BMWMottorad".media VALUES (282, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7459R0azYSaTHJoS0UABLixdasdRlIgL2d69IjEWQpXcE6WPhDqQrOEV12bwHN2g0KaZG7LuQy4yX9xzOUm4BY1Tr7A7shKQ5yRNoKSJl41LjOscD3hyj8gc8ZGqRVAEm8J1LlYH', 49, false);
INSERT INTO "BMWMottorad".media VALUES (291, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3331TnYN0JeiSPmeruzHGflrYXUrOrpW9jDdnuLhLopRBGwnJFt6QwfxqYZJFs1RUQgyh8H5lk3XqqfNwxz3DIdvQFzaJJE47JoSEQkPNHCZvhJPFskJEwlJT2K7nvz5b9PdO30l', 51, false);
INSERT INTO "BMWMottorad".media VALUES (301, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6446W2Hfq0j2MyTgmOcoAx4QUMwkzoTevaEkrbatqgXPWcn27NK3ZjPqJ9ynUEDYozrKuBbfOn%256sJLw02dizpVZhMr3g0NXUZ%25y6GxWm40aZrz2NhPTyxKStkxqa0MbGKlOxLqO', 54, false);
INSERT INTO "BMWMottorad".media VALUES (184, 26, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6925xLxtSweL0Lk3qM79PCrIXPlHV1eWqLCWYUBghDD8i7kLvE9MQJshNZLeXCuO9KYc0VUruksnlNK68zSCo2cmb%25YuDwEOXQsBjmCxdtsBmXKzEfsJzCc4yNwJz80Um1TMCoSu', 35, false);
INSERT INTO "BMWMottorad".media VALUES (185, 26, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-52219zwRP50PC9s1w6VJLcbypN6P%25tW8Hfz6VJ7faR50PwzL2rt%25B42r6JURf%25y5oeCbPWC6P%25mVJl5oeRa4dCH50Pvoe6lKkFOw14Wu6P%25n6lKkrs50PImmPme6lKkbC0au50PY', 35, false);
INSERT INTO "BMWMottorad".media VALUES (181, 26, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4617qRSbJwhVGctwpjEffvm0S20dBPk4h%25zY0VQZMqJYQB7p8N%25ujWmUXFlyGGhkpUSDDD4EuF5heYQbWnA54kXoj3EOa8tAzFI7rUwczlgfKHaXNN8FoDQa1ONOqrEvuacXbBJ7', 35, false);
INSERT INTO "BMWMottorad".media VALUES (182, 26, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3521fIEGHpWHZfx4ECFzdb%25Q7KCHNsoiV0ICFzr0vGpWHEIdm8sNqPm8CzwG0NQpSLZ%25HoZCHNXFzRpSLGvPOZVpWHYSLCRhBMjE4PokCHN2CRhB8xpWHDXXHXLCRhB%25ZWvkpWHF', 35, false);
INSERT INTO "BMWMottorad".media VALUES (192, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7220FtvlANCcwBTt9bCHqA2JpzoGff22fVRJ4dNQBG9vtsvruG4nfilhkKE%25v8v150pAar68npjJ6JaMgkz0luw5k2eHjHzPOvPC0B60CLQMlxYbGPHp1ycFEd9VjSmaj%257pdfAn', 37, false);
INSERT INTO "BMWMottorad".media VALUES (193, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5166h85rDLfeAZ1zagdrK0qF5zSsoS7rLaoGacpuPyZOCUQszESRkA%25YGlTluQBZy16MmEt%25Cbt5W7PrAcPtTNZXkmdM6zYIUfaug1BZnK3ogE6HEALfeiI6D1mUF1dqIfZZTVDk', 37, false);
INSERT INTO "BMWMottorad".media VALUES (186, 27, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7569n3y9s04mUgNZAgld4SUElYGpkgnUXWfic5pygqEsDrwDhPgDe2XTiNSlyVFE965aKGcnOfNM9EjaAAg6YyTYmKMdNPX6qs5lB1gzzkw8XhAcP604mTMtwcAvZtyUNb%25LBesc', 36, false);
INSERT INTO "BMWMottorad".media VALUES (187, 27, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6150UeiwefnQz55wsGBmROQSncgHh0OJYg0n0eshUNoXCYhJQcPdZ2K2jFUtSBEVCcn8fK8idTWZbnQVIirqse73x4YeybW5ixu79WkaPyYoD2WLcHbTm4kq1mdM927mqUdFRhej', 36, false);
INSERT INTO "BMWMottorad".media VALUES (188, 27, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6969xs1qknOfMPaF5PNrOXMzN%25hoRPxM023LIWo1PtzkwAJwYjPwp90ELaXN1QgzqHWcvhIx83a6qzic55PH%251E%25fv6raj0HtkWNGdPZZRJe0Y5IjHnOfE6uJI5bFu1MaDT7Gpk8', 36, false);
INSERT INTO "BMWMottorad".media VALUES (189, 27, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5057DMhjAeH2gegoTRXF6pFVZQQIrbpEmxl3LEUTD0Du6xrA8vbldn3V3jD7TcwDBiGj1On86W%25PYOs7zFDzKiCCa1xEnJpghahPQ%25vKbtMWRV%25Xv%25eH2JizASz2vnPFzH4K4UAu', 36, false);
INSERT INTO "BMWMottorad".media VALUES (208, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3273Cp8ze22VDera0nmLfMEP8s%25%255PcBSR6gCTQOmdccm4Hp2O0xrNMKX84a3NF1PUs73NLiia5wYXMzNVQ55ggrrDmZa2VMbydDVUyeBB1brDakOWyyKWEapGkCRtmxuFeglleD', 40, false);
INSERT INTO "BMWMottorad".media VALUES (209, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4257LoHqKhfD2h2%25dgaWmYW05nneRiYrTUQzurpdLcLVmURKGjiQkIz0zqLld87LMt6qsBIGmb19yBZlAWLAPtXXOsUrISY2HOH9n1jPiCobg01aj1hfDStAuN3ljI9WAfxPxpK5', 40, false);
INSERT INTO "BMWMottorad".media VALUES (210, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7269FVu6QZRJ2BrncBdNRE2XdLjD4BF2zUCY5IDuBHXQoamoiGBobMzSYrEdusxX6qIA8j5FKCr96XhAccBqLuSLJ89NrGzqHQIdPlB004mvzic5GqZRJS9y55Vynyu2rp7%25PbQK', 40, false);
INSERT INTO "BMWMottorad".media VALUES (211, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4342HT48FtFF8HfWfUe3jHo6sAUSS9ubMKnUe3iK5stFF4njlc9FjVlcUO9sKS6tJO8oFusUSSpe3ttJOw5V2sMtFFCJOrrkDBQ4NVudUSSXrrkDcftFFyCpeCXOrkDowh5qtFFZ', 40, false);
INSERT INTO "BMWMottorad".media VALUES (203, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3421ugVbL9BL4uKAV1OQXMJrfI1LzNqodkg1OQ0kUb9BLVgXtWNzYetW1QHbkzr93m4JLq41LzsOQc93mbUe54d9BLw3m1cDvjpVAeqa1LzG1cDvWK9BL6sDOizvcDvJ4BUa9BLw', 39, false);
INSERT INTO "BMWMottorad".media VALUES (204, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3565fi9BSzA79pKGhy2h7inyuoMo59G%25UuWc1XgqOoXa%25IdEX31RaR7m9NVQdc9gXku%25XFzrRukq%25cTjoH3OBhHhHg6ZOL8sa9C6kwnVN4yjFCpq34LuGYBOc1i5vQATpQvUZ5St', 39, false);
INSERT INTO "BMWMottorad".media VALUES (205, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5111hcsHrrQ94Xiq6wRA5lWfmBk0DmMq4efpQNcvT0IKyRm92FQFsEUnCRXEmfsqAZmM6HWOFmTOcpN9jejLHtm2elQ2PtF%25msnJZhlhbGV9aiZkFgtmc5uhv3MsXjbNhEZs6DrF', 39, false);
INSERT INTO "BMWMottorad".media VALUES (206, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7266FsltOBbku79LyXqtV%25ISlLhwKhGtByKZy1RM0273prmwLihCJuPgZ6j6Mmz7295AviUPp4UlNG0tu10UjH7YJvqA5LgdrbyMX9z7TVDKXi5WiuBbkxduye4yS9qIdb77joOJ', 39, false);
INSERT INTO "BMWMottorad".media VALUES (202, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-31591J7m8D7pB2IDJ0TQvKVY7HY1iXsvZYxFXRoztcwSoxzkO5gt%25loqhZAWBLZsJd7f4bvjtGuGwFVml0UuQ8hp%25bTbHOdtEG1LIdD2iuhvRlHS56OGRbK5g04j1qToUN2hvi8x', 38, false);
INSERT INTO "BMWMottorad".media VALUES (201, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4824iQqaK0C49n6PAzWasGHEq0ivwinaPMwnM5OcGMjKDykmPXiD41ZLnISqck0ju6d9egyGOp2qUj7a16G2FrTB4eW9IPLNyCucB6%25nSwV8LXIrX10C4XW1MfeWx6WHNRnTFsKc', 38, false);
INSERT INTO "BMWMottorad".media VALUES (238, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-52509D%25fDVgRnUUf4ijC8vRzgWGuLFv37GFgFD4L9AJZs7L3RWhax6e6YB91zj0ksWgbVeb%25aXMxogRk2%25cy4DEQPK7DloMU%25PdEHMO5hl7Jm6MTWuoXCuVX5RdpH6ECy9aB8LD0', 45, false);
INSERT INTO "BMWMottorad".media VALUES (239, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3720yKEbmDPJFlUKkzPORmsg06nNBBssBj%25gLpDilNkEKhEovNLtBAbaYTMIESEefq0mwo4St0rg4gwQ1Y6qbvFfYsXOrO6d7EdPql4qP5iQbuczNdO0e1bXt4Uer2xwrIW0pBmx', 45, false);
INSERT INTO "BMWMottorad".media VALUES (240, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7512nf65oiDQqGr0N069oxHZNYB8fELug6VYAaK2SagKJAwbBZEkCyFXYd%25H2pLguyWaRxl7JOWtHXGdluSrzrz%25mRIHqEPl14I1FqXijbVp0hrNZciDQoWXCUyELcAHcD%25in4oJ', 45, false);
INSERT INTO "BMWMottorad".media VALUES (241, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3821J5SPqbIq0JFkSfnXleLs%25OfqdVDh3z5fnXNz8PbIqS5lwKVd6BwKfXoPzdsbTY0LqD0fqdEnX4bTYP8BR03bIqiTYf4jg2GSkBDQfqdUf4jgKFbIqrY41xjp4jgL0I8QbIq1', 45, false);
INSERT INTO "BMWMottorad".media VALUES (242, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4627qzDsZ1iTRy4lo2mexHCrma6gh2dCa4xtsmYDyJtGLCZLW12BSDyItfWQDPWtsmQDP5wIzx4KsrIDKVym2Od2nPKe4c2meGvmusaMASZGyNKs1m1iTnwrLs4r6CDC4xcuASZv', 45, false);
INSERT INTO "BMWMottorad".media VALUES (243, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2342sAGY9Q99YsZwZm%25FusE3gbmccC47fiMm%25FliDgQ99GMuOpC9uxOpmhCgic3Q0hYE94gmccT%25FQQ0hXDxJgfQ99n0hvvPSHBG8x4KmccIvvPSpZQ99qSQ2jPkvPSEX1DVQ99S', 45, false);
INSERT INTO "BMWMottorad".media VALUES (244, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-29633tLhaK2aS3L3zKXZUOTbhvK2aevLvTUKXZMTbSK2aLUUbeeytTbeK7JSTabKXZSTavFK2aPXZoKXZFbTsFvK2aPXZoKXZ6ELOTvRK2a1oKXZeLK2a17oHPX8KXZThabpK2a8', 45, false);
INSERT INTO "BMWMottorad".media VALUES (245, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2250NQFKQe7wY11Ko0X8fCwj7uEInLCvxEL7LQonNqOibxnvwuz6%25r3rZTNWjXhDbu7Ve3VF6Gd%25k7wDlFH5oQPpSJxQUkd1FS2PAdmtzUxORrdguIkG8IeGtw2sArP85N6TfnQN', 45, false);
INSERT INTO "BMWMottorad".media VALUES (246, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3866J9Gxy3NqB80OgpnxMKTeGOkcuksx3guwgPtzoX82ri5cO4kUIBVCwZQZz5D8X07Ll4EVrHEGhsoxBPoEQF8RIlnL7OCjiNgzp0D8vMaup47S4B3NqWFsNLFpe0nTjN88QAyL', 45, false);
INSERT INTO "BMWMottorad".media VALUES (220, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3447u3ZOQbSfTaAosjGCvb8Fhq7cZL3bPZE0zeQY9cCxRzXODyzqTckIPnUyXjZR49hJKf3FqhaE80sVWLcuOmZKLonsU4rNPZt%259UR5iNEVV1uFyI4hbMw%25rQ86HqzsdyULmZQn', 43, false);
INSERT INTO "BMWMottorad".media VALUES (221, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7342cBwC%255%25%25Cc818lVezc4apHlPPrWsNfLlVeZfyp5%25%25wLz2tr%25zb2tlJrpfPa5KJC4%25WplPPQVe55KJRybdpN5%25%25vKJ66okSDw9bWMlPPj66okt85%25%25Tk5Ym0P6ok4R0yA5%25%25P', 43, false);
INSERT INTO "BMWMottorad".media VALUES (222, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-77294jNPjFlZ2s80%259yGxY7d6VUkIAYjttu5Mn0d4kztErITGVMv1pLR6q4fIaNBiK60SL0Hv6e9F5GLvNfmPn1gNFrnCSk8NN3cKejCMRULXReaVJS67khlp7B3KpcGmfmIiIjo', 43, false);
INSERT INTO "BMWMottorad".media VALUES (223, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-29623%25tinB9FNQC0FMcBYjZy1mqfMu7ZuI1yMYzUQbSr%25Wr0n4ApMoxOaqoJtNUFEk1TZPxWpcpaxyGn82mkxjHiyGyBpzme6recJvEJ1QtjxVwu4ezcSwi2pxg8R3r7pkb9gMn1', 43, false);
INSERT INTO "BMWMottorad".media VALUES (224, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3526fFyFBZ1ZMkbxXuaTLZg9coaCaNhGtylUHPBIppj5jHdhFJWKup%25KtuvkqM2TZCc%25iGS9K9e6gUYEwWR4SL2EHEuXm7Q8raQUpmTOlwlxiC41Jo7974YrmzYOwVHXKevNBaBd', 43, false);
INSERT INTO "BMWMottorad".media VALUES (225, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3371T9va96oAfLB22D4AINMsVYeGsRNcJkpKC1a8TZUedes1uYp%25DhrSosTTwfQtIgVylrym%25KG3lKuUPvj%25y13Hm5e1S57BvmEDXG1hphktWSGbY75KuG5VSMUxXhDA%25nP8ds9q', 43, false);
INSERT INTO "BMWMottorad".media VALUES (226, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-70325Dzvek%253nHdwKzFCoVQn%25rGax0p8jGjS0mDP928X4FP3blP5LIe1FFHI%25jBwCM%25RVmQi5Pcx3SQO1Gcrme0bZK04yJla%25L97ulV5TMY34IMZlHJPDuOha8CWH1jmlduBoxeH', 43, false);
INSERT INTO "BMWMottorad".media VALUES (227, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7417R%252zgFajNJKF0rMBBExq2sqpldYLaI6cqjiHQRgcilW0SDIvr3xV9yb8NNaY0V2ZZZLMvyfaXciz3tmfLY9nrGM7wSKm6yCWoVFJ6b1BTOw9DDSynwg1wZSoRoMEvwJ9zlgN', 43, false);
INSERT INTO "BMWMottorad".media VALUES (228, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7215Ff9AbP8JI0qiMjd13j1xaLBKm7j6z5DFH6muFUhb35mbgz73oMSiFMFauCXhNl2ARFuYDsrUIhX2WcFWx5nTJR56M%25nq9J1ULrBE7m4wnirdzrP8JKdhv1NgzMU1Ww7iZQb9', 44, false);
INSERT INTO "BMWMottorad".media VALUES (229, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5021DrLF2Ka2SDz3LoX7tOjfhQo2yJvBmTroX7uT4FKa2LrtbkJyUnbko7eFTyfKYGSj2vSo2y%25X7VKYGF4nsSmKa2PYGoVgZ5xL3nvCo2ycoVgZkzKa21GVH0Z8VgZjSa4CKa2X', 44, false);
INSERT INTO "BMWMottorad".media VALUES (230, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6246vbmTwa9bpf1W%25xOYRIn0epLZrY1GP4dZkj4JwWN2vOcbuQgEA92w7DfcediHYrkgCUjTxcyoz7tLabsqrhXA6pkEWaQNeAyfoMIv%25na4AkrbQ621fTzZGGal4apjMgVxItwx', 44, false);
INSERT INTO "BMWMottorad".media VALUES (231, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5640bwsF4HcOvJlMXiwnfNXXeoSP2Z2ZnslnO%25bRRdt5KOIwae7juIIoTmQ9CMFUGdkPQHSgT19bXT1E23p5yBSAHmvguHmyKauVCut3BSlQAR5JerN9DLXniL2WwtOgUgQG6a40', 44, false);
INSERT INTO "BMWMottorad".media VALUES (232, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-49546hwwBHX7m1fAeuwVBWk1kraPFHyOrwBUOpzpICULjO0F29HnxpIUUQAepE2UOpepEW89TYkfkt9vw3IfabyuZEvkvNuwVhQVqvrN5hBxAdfk9VHX7LJtEf8NaVOkVYAW5hBR', 44, false);
INSERT INTO "BMWMottorad".media VALUES (234, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-1734kvfZ4yUpJOMA%25GoFV5gPVOiFWZ9gGvU%253j84Oad6mJlvl87iN6HkPvfUf9Bq7UozJM7gEruCGP9LICDUNLgHIeRFuy3rw6UooHHVjZ5bHfdD8ratC0G%25xGIIm1bYuTwnUN4o', 44, false);
INSERT INTO "BMWMottorad".media VALUES (235, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6649gBhqPfR00g8Ja6j1Be5aPG6dCUDaNLb6j1GzSp4pPF4BwTrqf4sn5XnpLRyftk05%25OI6dCvn954re%25FfRqN4pPEtkfLoXwOFXfDilIRn4zVgT84pPU961ueRBKY6pISA4pPC', 44, false);
INSERT INTO "BMWMottorad".media VALUES (236, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3444uVFvOmn4F9q4DZZD4KRZjqTIxS4J%25jBhhswg5dwZkXXKwlF1Z9btSLdUYFSss2jJ83QP1T2gJhppdBl6QDzOLwx46vWW7hcxaNCdBu7C311glMvTf1kF6oI4UUTC1tU%25fxOI', 44, false);
INSERT INTO "BMWMottorad".media VALUES (273, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-18570srNwERVuEuZWLMtkztGqhhfDXz2FyePc23W0608kyDwTSXebHPGPN0IWmn01adNv%25HTkC5lA%25jI9t097aBBovy2Hxzurorlh5S7XOsCLG5MS5ERVfu%253tclSHlt9RY7Y3wt', 48, false);
INSERT INTO "BMWMottorad".media VALUES (26, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6465W403eDL80ruskgXk84mgBAzA70sKEBS%25PpCnyApYKTjbp2PtYt850hM6j%250CpqBKpJDitBqnK%25vQAF2y3kFkFCZwyO19Y0UZqcmMhHgQJUrn2HOBsR3c%25fHal6Lvr6lEw7eL', 53, false);
INSERT INTO "BMWMottorad".media VALUES (27, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3847JTrnXPu%25yQkhE2U7gPxAMDt4rqTPWr1NdBX6b47cZdlnjmdDy4zOWa8ml2rZ0bMLF%25TADMQ1xNESKq4JnYrFqhaE80sVWrwHb8ZR9V1SSfJAmO0MPSSbIYfpoDdE3m8qYrXa', 53, false);
INSERT INTO "BMWMottorad".media VALUES (28, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2244N4PDe3B8Ptu8JggJ8bvgLuzMG08VELh%25%25RCj2ACgKnnbCaPrgtwl0SA6TP0RRqLVpkOirzqjV%25mmAhayOJFeSCG8yD99X%25UGIcQAhNXQkrrjaHDzspDc0bH266zQrl6EsGer', 53, false);
INSERT INTO "BMWMottorad".media VALUES (29, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7233FpdI8XoJNjyGr7d68YtTUL0mCY01zdsB9AsuEuL8b9mR%25nYb3MizBW7UuDPL1MtA3Ydj4KratLTNqcEyPa%25ZJ3HtWgGq5RN5xWBYFCsOGiyUnlXoJGHM9aMe%25l9tlV7ghR8v', 53, false);
INSERT INTO "BMWMottorad".media VALUES (292, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7962aVEfvD%25eF5rKeLPDCm8X0lTNLzs8zj0XLCOi5HkxVhxKvWBtLub2gTudEFie4I0Q8obhtPtgbXwv9YlIbmSfXwXDtOlq7xqPd64d05EmbA1zWqOPk8k2z4MjUaxstIH%25pLvd', 51, false);
INSERT INTO "BMWMottorad".media VALUES (302, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3964%25hjWSQRTiivDHlitXfUN0SylD1fayFJqg27Z%254pwgSDhoh91f3pGI7%25C7QUR1s%25HERNrcC4LuIVqJT0eDylfViS2DQLvjVKzh4wG9H80fG4xhfvpnvaeXrVzF3ztedgWkOS2', 54, false);
INSERT INTO "BMWMottorad".media VALUES (247, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5149hi71YQegghDsWu%25aiwMWYLuckqfW5Emu%25aLxZJvJYGvi30I1QvOPMFPJEeNQd8gMXb9uckoPyMvIwXGQe15vJYnd8QECF3bGFQfTA9ePvxRh0DvJYqyuargnipSuJ9ZUvJYn', 46, false);
INSERT INTO "BMWMottorad".media VALUES (108, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6342BpuN3P33NBMzM0a6RBIxHT0DDFjAndC0a6KdEHP33uCRiSF3RqiS0lFHdDxP2lNI3jH0DDca6PP2lWEqZHnP3392l%25%25y5QtuLqjY0DDw%25%25y5SMP33G9cD5Zl%25y5IWOEgP33a', 18, false);
INSERT INTO "BMWMottorad".media VALUES (109, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6461WcckHS0y6qGLC41QWFCpqMeogwYsmc7m2oNUrjEZu2ncgI8mLTjMvll0rBJi8jIK6SJCQ%250HCv0fXaU7XOeBh56RBS6gMXBAtBEy3k76Br7dIiFPaB4jDVpN9x2REpls7XHQ', 18, false);
INSERT INTO "BMWMottorad".media VALUES (110, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7158O4RZJN5sCVuagYeYsligbvBiW%25ynEba0C0pVwAq1oKr4I8PT1ryf%258v6odPI0I4np17EnlIVn%25MxMws2HXFc2RDF2NJ9JItDR1Mvh79vcVtV8HW68qG1XPzD4l4EtBfEyNJP', 18, false);
INSERT INTO "BMWMottorad".media VALUES (111, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5451jpHtbTRQNFcilB56Q01LdX0eK7E2gdm7HNDaE9Zb8asRGi78byi%257MYdaDZZNWI23BUYsCWa2ZX1cMEMT5iLQ3UAMnzl532UZlYYEK4kzSyairTRQGUl4HPr%25qd1yp0gxobW', 18, false);
INSERT INTO "BMWMottorad".media VALUES (248, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3044SNK2IyOcKiLcqRRqcW5RDL3B8VcufDeoortvgztRAQQWtXKERi97VJzGmKVrrjDuUdabE3jvuo66zeXYaqkIJt8cY2PPCox8n0lzeSCldEEvXh231EAKYHNVGG3lE7Gf18Ib', 46, false);
INSERT INTO "BMWMottorad".media VALUES (249, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4453wYy7jTAXlkQPLadxLLG5Mb9CHAx%256clduZYAVp0UFduXF8MsavnKIdkvMl2PxDMizGGHsuKNgd7YVco4GTAF9BuhCj8RMao9OsLwlOrXSmD18JjuYDYqC%25EtkV5ZsmO2BHjs', 46, false);
INSERT INTO "BMWMottorad".media VALUES (250, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4048t7skSILio13Wmc4pzaVu4cW%25YcUV1DBMefPs1pAhGKFGydc7X8cUMO2fsjaAkbbwnHJrGB3mkutwQv1b18t1xnmp3q9bCh44lJ96lgFFcaQedbILiiJuZkBOHosV3LI66XSL', 46, false);
INSERT INTO "BMWMottorad".media VALUES (251, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7234FjE5x3pYSBoK16%25W0v290BtWb5w26jp1zqGxBOkmTSQjQGlt4mfF9jEpEwMJlp%25ASol2rRVX69wueXLp4u2fehgWV3zR7mp%25%25ff0q5vifEkLGROCXc61U60nTsiyVd7Ip4xP', 46, false);
INSERT INTO "BMWMottorad".media VALUES (252, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5520MsYReKZbEqasf%25ZV3emz7ISt00mm0FGzPOKgqtfYsxY8ktP201RuBhcNYiY4pW7ev8Ci27yzCzvJ6BIWRkEpBmLVyVIHjYHZWqCWZdgJR9l%25tHV746RL2CDSyAXvyNr7O0eZ', 46, false);
INSERT INTO "BMWMottorad".media VALUES (112, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3862Ji6GzFU013mE0WrFjBXqtDMwWHYXHAtqWjS538%25liclEzsNvWbZkdMbo61507VtLXxZcvrvdZqgzRIDVZB9GqgqFvSDK2lKroO7ot36BZfpHsKSr%25pGIv6foQJlYvV8UnWzW', 19, false);
INSERT INTO "BMWMottorad".media VALUES (113, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6773Idyb1SSUN1jhpoA45EvCy2RRLCYf8qzJIKMHAPYYA6ZdSHpmjGEtey6hWGwgCT2OWG4QQhLakeEbGUMLLJJjjNADhSUElFPNUTF1ffgljNh9H7FFt8kJwL%25vqnAmxw1JBB16', 19, false);
INSERT INTO "BMWMottorad".media VALUES (256, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2465Xym9rc8dmLGqtVotdyWVs7w7emqlDspvQAMfP7AKlb4aA0QBKBdSmRZF4vmMAxslAUcOBsxflvNH7C0P9tCtCMJIP1jnKmzJxTWZRgVHUzLf0g1sqB5Q0yG%25hF8NLFhDIer8', 47, false);
INSERT INTO "BMWMottorad".media VALUES (257, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3073ShBrGbbXiGk4ac%25tTpd2BzyyK2OUlFoWS10x%25sOO%25nmhbxaIkQpgNBn4EQ532ezuEQtqq4KLHNprQX0KKWWkki%25A4bXpjfsiXefGUU3jki4ZxvffglHW5uv9FJ%25IC5GWVVGn', 47, false);
INSERT INTO "BMWMottorad".media VALUES (3, 5, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5171h5ku5I81pP0AAKC1NtcmwB4nm3tlbfOsD6uQhTa4H4m69BOGKxyi8mhhvpJ2NzwMqyMeGsnoqs9aZkFGM6oUed46idj0keYKLn6xOxf2rinRBjds9q5GB6Y8LxK1GSZQHm5e', 17, false);
INSERT INTO "BMWMottorad".media VALUES (100, 5, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2518djRJzl7nwU3uwqQ3S2Ja32rEgWNQ2oSM3JT35vMB%25QGndqWP035lMmUO3SdM3JO3S1ec0GbJoucobK58c4NqjS3RQ5qQ304o1R2dyYzjdWJoqol7naDoBe8Crb8JRG9IyYzo', 17, false);
INSERT INTO "BMWMottorad".media VALUES (258, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7143OvwTmcHwJkctn%25JFfdSTOvi0rLdiiv5GbEoKOdHA4QrvyQBzItHVZVOHV9FWBu3nJWjSBWdCgZaZ6sD5tx%25d2eQEUcRcw2aRQduVBTu3dVdeQq9Ns0gGTSlhmtRF5Zfn5tmB', 47, false);
INSERT INTO "BMWMottorad".media VALUES (259, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7428RDkjoWrKoR9IX7Q%25DdZgV87jtiaXFOW7Q%25wDJtHUoJNDcmxnHW9QGpQtOrXWiIoZVyn7jt6mPGHEqKkNtjFHUobiIWDup92JCNabZTrvH3ACm9HUoEP7PLdTOMRGtTJBHUo%25', 47, false);
INSERT INTO "BMWMottorad".media VALUES (260, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5034DCKio51sOmdqFEkLet7Sem0LuiN7EC1FvXfom62rROUCUfx0MrADSCK1KNTax1kjOdx7P9I8ESNny8Q1Mn7Ay3wLI5v94r1kkAAeXitVAK2Qf96c8hEF%25EaSRWVZIg4Y1Mok', 47, false);
INSERT INTO "BMWMottorad".media VALUES (262, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2118zD5ukXCOtGdStLadVjundjZsvP0ajHVhdu3dg2hefapOzLPb4dgXhyGIdVzhduIdVEMx4p9uHSxH9WgUxc0LDVd5agLad4cHE5jzTmkDzPuHLHXCOmWSwa9DZ9Uu5piBTmkz', 47, false);
INSERT INTO "BMWMottorad".media VALUES (263, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-65138VmBmHqkwbrrXzpGpAhXCbnZ6L2hzKqgf%253QbH1uKwAVuDBj5A68XKQdmyE9zdpx8UzSTIUJLX2E1JfdlES69skGUH4qDudpC56R0zMQ6Q9bDqNdeXLgnLcgV2vSU%253%25I5mx', 47, false);
INSERT INTO "BMWMottorad".media VALUES (264, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4437w3KhpaHJVv6c%25Pp0JNz0DfZLyj1iLD9TVjKQkltIvvM3UJnEIu1OjefWmUnUjrOiKdFLxWrQij6L5JecyPXI1VwYcaRICtMwoq6fgSd4IvMQJ22NkxiTgG6gDHOBMGOL12p3', 47, false);
INSERT INTO "BMWMottorad".media VALUES (265, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4540YTnUgCvPhEkwAyTWXRAAi7r6oIoIWnkWPlYBB43eGPbTKidHsbb7NSFmzwUDq4x6FCrMNQmYANQao0LeV9r8CShMsCSVGKsZzs309rkF8BeEiORm%251AWy1oiT3PMDMFqJKgX', 48, false);
INSERT INTO "BMWMottorad".media VALUES (266, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-52599eGvsOGRzadOe%25jmQVogGWg9xYwQ7gESYCKLU18hKELJ3lXUP6KIF7uNzB7weqGbf4QnUZMZ8Sov6%25rMmsFRP4j4W3qUiZ9BdqOaxMFQC6Whl53ZCHwhHbli9IjKrHaFQxsE', 48, false);
INSERT INTO "BMWMottorad".media VALUES (267, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5362pBWF7XATqwbLTauXxZ%25UM85ea2P%252lMUaxYNwkjHBdHL7Jy4aOSCt5OvWqNThmMG%25zSd4u4tSU07Vr8mSZIFU0UX4Y8QcHQuvshvMwWZSDK2JQYujKFr4SKlfpHP4mkAEa74', 48, false);
INSERT INTO "BMWMottorad".media VALUES (274, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5117hafUH6b1vZY62eCttIqsfBsSK8NrbwVDs1dQPhHDdKm25Ew%25exqg34TLvvbN2gfMMMrC%254nbWDdUxk0nrN39euCAz5Y0V4FmXg6ZVTOtciz3EE549zHOzMM8hXCI%25zZ3UKHm', 49, false);
INSERT INTO "BMWMottorad".media VALUES (283, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3024S8lUDB4euG1L2gqUK%25dFlBSwVSGULyVGy9pM%25y7DCrvsLxSCeAPXG6nlMvB7a15umir%25pftlH70UA1%25tjWZYemqu6LXIr4aMY1zGnVOoXx6WxAB4exq6yM2Xh1qdIbGZjKDM', 50, false);
INSERT INTO "BMWMottorad".media VALUES (293, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2664VJmhk5UQff6ySZfERNiFKkXZy0NgXedTpYs8VWt1pkyJuJ%250NatwjsVrs5iU0cVS4UFxPrW3zjATdQKqyXZNAfkYy536mAMOJW1w%25S9KNwWbJN6tv6gqRx6DeaOEqnphI2kJ', 51, false);
INSERT INTO "BMWMottorad".media VALUES (303, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6660gRcamE4CH%256TNgr5DGa7l7%25VwzzUZqOnlaplirjmerfCXXzee6xxnt%25llOYj5255DSySkfAydjFdAIiNFMLYCDl9txXtleuqF1GgGwvRXL2qXIE4CZlIlrNAPAWa1bSX7sm2', 54, false);
INSERT INTO "BMWMottorad".media VALUES (31, 6, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-31331noVXqxPwAeam2oOXIvMQWtBjItpHoYNRfYb6bWXZRBTUuIZh45HNs2QbFrWp4vfhIoA7EmJvWMwKC6erJUyPh8vsdaK3Tw3lsNI1jYSa5eQuDqxPa84YND5UDRvDi2dcTX8', 1, false);
INSERT INTO "BMWMottorad".media VALUES (32, 6, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2151zQc5sBmD9%25tZ2SyaDiUFMjiVfgGdTMOgc9kqGrYsCqpmXZgCsIZxgNnMqkYY91udeSlnpv1qdYjUtNGNByZFDelHNLh2yedlY2nnGfwohPIqZ6BmDXl2w%25NPxAMUIQiT74sp', 1, false);
INSERT INTO "BMWMottorad".media VALUES (33, 6, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3334TZh1Sp4xjXO3McBdLsrALXWdk1KrcZ4MY50SXCm8GjwZw09WJ8eTAZh4hKav94ByjO9rHfDicAK2Qig4J2reQnEdDpYfP84BBeeL51sFehmg0fCbiKMKyZw8GoFUD6Pl4JSl', 1, false);
INSERT INTO "BMWMottorad".media VALUES (34, 6, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7144OBq7YZ6hqVQhX99XhLi9lQ5mHIhnAlyddP0twv09jUUL08qK9VS4IavfrqIPPCln%25gGuK5CtndEEvy8sGX2Ya0Hhs7JJcdoHpexvyOcxgKKt8375F%257eJV9cff5xK4fAFHY5', 2, false);
INSERT INTO "BMWMottorad".media VALUES (35, 6, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2831l5tkATjHdM7j43aJ9Ss4trb4g4ieo6YQ53yqyLix29%255TIfwZ%25SWmtcTI0VxbZUCqPJ8snXrmmSk%25WaXYvQGZIaRTTNF1TLdNZnMkJEcGqTMI0nTN%25sTvyD25Ga8hoMQgXA9', 2, false);
INSERT INTO "BMWMottorad".media VALUES (45, 10, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4345H7QRzMESV58uOyJR%251JHQAW7%25W6RA3%25l38Xo9OlBgRnGurWXFo9ylmdvonul38vontCcYiRQb5cRos9Rq46yFnJoQuyJREDo28A5q0z0arQbroMESE4gQ9EUW8JJJi56q0zR', 5, false);
INSERT INTO "BMWMottorad".media VALUES (275, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-77544aFFlO9WxeBmXvFjl3YeYowdyO87oFlV7060CPV5r7qyskOtu0CVVimX0MsV70X0M3SkUcYBYKkEFGCBwz8vHMEYEDvFjaijREoDfalumpBYkjO9W5gKMByzwj7Yjcm3falE', 49, false);
INSERT INTO "BMWMottorad".media VALUES (284, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4855ihYqgo3Li%25ws5qGtZku67%25yrCIvuqF3l%25NjX%25KfkSiehJTd2pJpi6FgDYQ9bIDG9E8IMyDsLd6vcbL0DCcMpfiztsoPOjkDGZCpGHdJYpg4PTOVOzv5mPqk4FQgAsHnWOpgg', 50, false);
INSERT INTO "BMWMottorad".media VALUES (294, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2048QagPcoNlERFwzpGTWex4GpwrdpmxRSHf%25ZtgRTb1yi9ykKpaIYpmfhJZguebP77XMs0vyHFzP4QXBLR7RYQR6MzTFVC7n1GGO0C3Oq99peB%25K7oNlvBE%250lSsEgxFNo33Ic%25', 52, false);
INSERT INTO "BMWMottorad".media VALUES (304, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6618gC9avx4pN%255nNXU5O7aG57PKwLBU7dOT5aR5itTmkUfpgXLJe5ixTr%2565OgT5a65OFyhefuadnhduqiHhMBXCO59UiXU5eMdF97gZsvCgLadXdx4pGld5r4cPuHa9fSYZsvU', 55, false);
INSERT INTO "BMWMottorad".media VALUES (157, 20, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2563d7JonWjnVdJdkWQRGI39o2WjnM2J23GWQRh39VWjnJGG9MMT739MWCuV3n9WQRV3n2KWjnbQRHWQRK93rK2WjnbQRHWQRYsJI325WjnEHWQRMJWjnU4b%25jCbWQR3on96Wjnb', 30, false);
INSERT INTO "BMWMottorad".media VALUES (158, 20, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7531njXWPkJEF%25QJUABN745UXgtUDUCH1T3IjAzSzVCpL7sjkhrlvs4idXGkh8cptvYaSwN65eOgdd4WsiBO3qImvhB2kkxbZkVFxve%25WNRGmSk%25h8ekxs5k14sZjmB6f1%25IDOP7', 30, false);
INSERT INTO "BMWMottorad".media VALUES (159, 20, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7465RXl%25xP9nl3wTEAuEnXhAcs1sqlTZyct65BLNosBMZHWgBK5DMDnklU8eW6lLBbcZBiP2DcbNZ6FSsrKo%25ErErLdjo0mvMlOdbQh8UpASiO3NKp0cTz%25QKN8lJe9F3eJyjqxD', 30, false);
INSERT INTO "BMWMottorad".media VALUES (168, 22, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6167UArCWGhA1uhLJV6w1YRJy9vb08FbkMXf2puaHzBGr6FAnrsKnF7HbluSyXKzw%25289%25ppoFGdQb0m7uNgPDwjic2VzGrLynGAqnYUepZuja%25urx7SMRQffUPvA71pnwdVY%25Wj', 32, false);
INSERT INTO "BMWMottorad".media VALUES (169, 22, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4232LNbu19RWoZPatbwIrUMoRj3hmpdyV3V8pANCXSye6wCWlBCL4%251gwwZ%25RVfaIERqUAMQLCYmW8MHg3YjA1plDtp6FcBhR4XOxBULKEkW6%25EDBZcCNxHshLx7ZgVABPxfrm1Z', 32, false);
INSERT INTO "BMWMottorad".media VALUES (170, 22, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4662qbG83kxV%25y6fVFEkvOCji2B9FhpChzijFvJZyco7b07f31S5FWsdTBWMG%25ZVwuiDC4s05E5TsjR3rn2usOP8jRjk5J2Ag7AEMawMiyGOsHUh1AJEoU8n5lNrlq7p5ucxQF3S', 32, false);
INSERT INTO "BMWMottorad".media VALUES (194, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3925%25n%25cB43nhnDvadxNS89yGSUAeW3uan8uZ1T7zQQf0xDnCPNdpObzMin3G8ImNJZHhe19IDbYUMJrfjB8klHRVFZIQ4PmGpbTXR8%252cbTRGJjPKbOj8Ho5cLzjfh1RWgd8kBY', 37, false);
INSERT INTO "BMWMottorad".media VALUES (195, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3938%25d869awt3gjaqKvl6uuC8hCPbR958R4epruDiPcJuf3IyZpxoZAjJwzh3D89qn8HWN5mx8zs9eM6Zoxz6cJroHvWSyTEb80OnnagfBe6t7SeZ7y8UNASgrWb%25TvMihgJlb9V', 37, false);
INSERT INTO "BMWMottorad".media VALUES (196, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-1743kOpLDr9poVr6zio0wu%25LkOGElhuGGOag87b4ku9Ns3lOq3FSA69fXfk9fU0cFHJzocB%25FcumnXdX2Cea6ZiuIK375rQrpIdQ3uHfFLHJufuK3MU1CUGaGZ8vD6Q0aXwza6Da', 37, false);
INSERT INTO "BMWMottorad".media VALUES (197, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2120z9RtduwNbnY9WKwM2d5D8Texoo55oJsDVyuCnxWR9fR1qxVXoPtB3k%25hR4RHrS8dl1U4X8gDUDlIZ3TStqbr35OMgMTFQRFwSnUSwjCIt0GKxFM8H6Nz%25yWJgLplghi8yodP', 37, false);
INSERT INTO "BMWMottorad".media VALUES (198, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3436u0bJ%25WEzOH39ky3bn2b9QIqFgr2RIRnMoRXJuwM0nRg%255qrTFJucMeuvJG5MoRvJGAelji883ulQo4uocC2yBGRRJHy3bB48I8I9rY%25Eac83q8WEzHCo0CnsqJ8boiU1rY%25b', 37, false);
INSERT INTO "BMWMottorad".media VALUES (199, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-1920rDFJsCLQjcHDvgLpbsKiB1GIYYKKY7ziXfCScIvFDTF3wIXNY2JUEZy6FnFmklBsV3enNBWieiV8AE1lJwjkEKxpWp150F5LlcelL9S8JaMgI5pBmoQryfvGWthVW6qBfYsh', 37, false);
INSERT INTO "BMWMottorad".media VALUES (200, 24, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4859iMp2rIp5knzIMfDyaNHvpPvi8mtaCvsVmlWJGEUoWsJudXQGbYWBKCS0keCtMLp91caOGRhRUVH2YfZhyrK5bcDcPdLGwRiezLIn8hKalYPoXgdRlcNPjl18iBDWZ%25nKa8rG', 37, false);
INSERT INTO "BMWMottorad".media VALUES (63, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4261Lhh2zOeZEXfQcMFULDc1XTydwNsWrh4r7dB%25PCKbn7phwYHrQRCTtxxePmaVHCYqEOacUkezcteA8G%25486ym3iE9mOEwT8mj0mKZ524EmP4gYVDJGmMeGTXXSo79K1xW48z0', 8, false);
INSERT INTO "BMWMottorad".media VALUES (64, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6665gaQ1U9wIQz7drKVrIaHK8ZsZJQd538CmvMu4%25ZMo5fb2MPvLoLIFQpGhbmQuMi85Mt9DL8i45mWNZRP%251rRrRukq%25cTjoQBkinHGpYKNtBz4PYc8dA1%25mzaQShwWzhS3qJU6', 8, false);
INSERT INTO "BMWMottorad".media VALUES (65, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7624AiRwTqPLkt4dm63whNOMRqAEFAtwdQFtQf7JNQrTZ8Yxd9AZLeH5tC2RJYqrv4pkX18N70sRVrWwe4NsyoUlLX3kCd5D8PvJl4It2FjS59Co9eqPL93eQN%258u43OD%25tUyhTF', 8, false);
INSERT INTO "BMWMottorad".media VALUES (101, 5, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6371Br3qra4H8FSddkwHu9NpbnVXpm9tKoQfvUqCBYlVMVpUWnQxk06P4pBBR8D5uTbI26IOxfXe2fWlE3zxIUecOyVUPygS3OGkjXU0Q0o51PXsngyfW2rxnUG4j0kHxLECMprx', 17, false);
INSERT INTO "BMWMottorad".media VALUES (102, 5, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-36397sW6p0owuFUXMZctvi6irxhk4Tn1EymXr68r01YROcKwZGTD3UP%25X1FtrmGYt5Utvz5LOKdl2gB2d20uBdj78vrN9PG9r3qyLHi7xfCsZn5yGa0owxUap5uNSdM6HoB7Ebpb', 17, false);
INSERT INTO "BMWMottorad".media VALUES (103, 5, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2517dpFfksSK79rsCTx44mQPFyPIL%25ebS0BXPKvGudkXvLZCwW0ATHQtgh5a77SeCtF333bxAh6SJXvfHjM6begVTOxD2wrMBhqZUts9B5Y4oN2gWWwhV3v2cKc%25dUxmA29gfLkj', 17, false);
INSERT INTO "BMWMottorad".media VALUES (104, 5, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2271NmhKmJ78X19oo%25g8bRwnZuiqnBRvExLGzQKjNIDi4inQsuLl%25tOr7nNNTXF3bMZVkOVSlGq0kGsD6hHlVQ0CSeiQred9hSa%25AqQtLtx3prqYudeGskmluQa7At%258lW6j4nmi', 17, false);
INSERT INTO "BMWMottorad".media VALUES (66, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7820ZqKurlJaDx%25q2vJ69rWweEpBmmWWmCkwQ1lVxB2Kq3KdtBQ0mjuGsRTYKOKyAXerNdMO0ePwMwNUFsEXutDAsW86P6Eg4KgJXxMXJiVUunhvBg6eyHaZTVTSP7oNPYLe1mrQ', 9, false);
INSERT INTO "BMWMottorad".media VALUES (67, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7229F6kM6Iscp0PAuoC9Wt1QwzbnvOt6ff38D5AQFnafN4vl9zDGViyxwmFSvRk2HBwAdyAJGwjoI89yGkS7M5VUkI45EdnPkkXKBj6EDxbyrxjRzTdw1ql7B80XBiK97S7vHv6s', 9, false);
INSERT INTO "BMWMottorad".media VALUES (68, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7156On5FSn2FaO4GLr1ZjGnlaQr8a9izuUrr1Zirf8TaS6UjLJ18UoBeUNk8Uy5nXOanhESr8apcGrTY3abVFhuTaSIXOToeH5m6OViptsyYjKkWJ4TaSF0pwcpsVJNTw8fdTaS8', 9, false);
INSERT INTO "BMWMottorad".media VALUES (69, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4315HxsoE17FJ9krVde8Bd8tDAu%25n5dQMmzH4QnKHCNEBmnEyM5B0VWrHVHDKg2Nbv3oYHKazGpCJN23fwHftmqIFYmQVcqksF8CApuU5niZqrpeMp17Fcmfi7JSMVC8fZ5r6jEx', 9, false);
INSERT INTO "BMWMottorad".media VALUES (70, 13, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6442WjfsSUSSsWbNbrkDnWK5wurhhcM4AVTrkDxVlwUSSfTn61cSno61r3cwVh5Ue3sKSMwrhhRkDUUe38loawAUSSpe3ttJOzmfHoMqrhhYttJO1bUSS2pRhgChtJOK8FlIUSS3', 9, false);
INSERT INTO "BMWMottorad".media VALUES (82, 15, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-2731Ex%25anCpLXjfpAlZyh3NA%250MA8Ao2qiwrxl7Y7moKGhJxCguH4J3Bt%25FCgkdKM4P1YeyWNRs0tt3aJBZswUrb4gZcCCzOSCmXz4RjayVFbYCjgkRCzJNCU8kfxbZWDqjr8snh', 12, false);
INSERT INTO "BMWMottorad".media VALUES (83, 15, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6632gqk2MAfdO%25ztWkKlHNaOfZpn846UDpDV4yqbijUQcKbd9XbgJBMEKK%25BfDetlhf5Nyawgbx8dVaIEpxZyM49RW4cTuXnfJiCSXNg3hmdcBhRX%25ubqW6PECiI%25EDyXzSeH8Mg', 12, false);
INSERT INTO "BMWMottorad".media VALUES (84, 15, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4339HSObPdjhmaK1vNkoxMbMVA2XztrJuwi1VbFVdJ90ZknhNWtG7KIq1JaoViW9o4Koxl46ZnCf8c58C8dm5CUHFxV3eIWeV7pw6DMHAL%25SNr4wWsdjhAKsPFC2yCvbDj5HuBPB', 12, false);
INSERT INTO "BMWMottorad".media VALUES (25, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-49636PvO7dZ7D6v6mdwf0lpAOrdZ7arvrp0dwfnpADdZ7v00AaaGPpAadb2Dp7AdwfDp7r3dZ7kwfIdwf3ApH3rdZ7kwfIdwfxovlpr1dZ7hIdwfavdZ7NJkwJNJdwfpO7AcdZ7B', 3, false);
INSERT INTO "BMWMottorad".media VALUES (216, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4858ijhMZvoBFgRbHN7NBKdHT%25tdma49ITb2F2SgzpsOXYejwLycOe4naL%25VX8yw2wj9SOAI9Kwg9aCqCzBfQW6DfhE6fvZ3ZwkEhOC%25lA3%25DgkgLQmVLsufSw%25NjKjIktnI4vZj', 42, false);
INSERT INTO "BMWMottorad".media VALUES (217, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-3564foDPVa53ww2q%25Xw7Q1G04VTXqE1nTKuLvjCRfc6tvVqoHoiE1d6pBCflCaG5Erf%25s50ZxlcJSBNLu34MqTX1NwVjqaJ2DNWkoctpi%25U41pc8o126O2nrQtmSKdk7MzvPAIVf', 42, false);
INSERT INTO "BMWMottorad".media VALUES (218, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6636gDd5OTeptnUz6xUdwEdz97ZmfhEH7HwXaHb5gAXDwHfO%25Zh8m5gLXlg15V%25XaH15VYlPskuuUgP9aqgaLWExCVHH5nxUdCqu7u7zh4OeiLuUZuTepnWHaOwKZ5udakSBh4Os', 42, false);
INSERT INTO "BMWMottorad".media VALUES (219, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7643AI6JqZi6HNZYkwH4tSfJAIpsXoSppInvUC9cASi0rdXILdKVFYi1Q1Ai1G4xK%25ukHxefKxSyOQzQjlMnYRwSBWdCgZaZ6BzadS%251KJ%25uS1SWdhGElGp%25r0U3qYa4nQtknYqp', 42, false);
INSERT INTO "BMWMottorad".media VALUES (43, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-1916rqWV5n0MNygx446bM0efqcCJnOEseqEDN3NaMY7La2SqGA3sLhEqOMc0y73G37IsNzoe8%257asOYkXuuETfmBxHtQEn6zlZFtNBYcQVB1ByFaAnjPu7KBHpxWdPIJFpqeET51', 4, false);
INSERT INTO "BMWMottorad".media VALUES (212, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4250Lt3dtabW8hhdIJwNM9WRbjoXCv9rVovbvtICLglKAVCrWjmxe%256%25fpLzRwO5Ajbqa6q3x4YeybW5i3BEItkcD2Vt0yYh3DZkTYUPm0Vl1%25YsjXy4N2UjmoEzT%25kNELxpMCtO', 41, false);
INSERT INTO "BMWMottorad".media VALUES (213, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6824Ktg7dJ9uFCxkTmz7H4BogJKrWKC7knWCnElS4nRd5GyUkwK5uhfvCXDgSyJRjxYFasG4lcZg0Rb7hx4Z3%25pQuazFXkvLG9jSQxeCDWqNvwX%25whJ9uwzhnMFtVxzBL1Cp3HdG', 41, false);
INSERT INTO "BMWMottorad".media VALUES (214, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6714I3YKoDjVjI1CJ7xROCOYja7tnxskh7Z7xR8G1rOnoXGOkuitGWJMZPAr7TXDQdjOK8V7tn5ip7Omqj9HoohOnoLQdOHA0g2XIHs6GUTv3Wu%25u1Onoo4ui0dqNMP3Ut1LOnot', 41, false);
INSERT INTO "BMWMottorad".media VALUES (215, 1, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-65418juzEGdXabonY5I7Pih9d4U3l6Sh6UI9607MbOXMj2MTxDlolvBw1tQpu2AgBCdxSjLaoqKcL9hik94CBE2LcF17KZ4RHMRIR4zRq4AxBvelDRZqYFgDldewowAFKR3IPlEC', 41, false);
INSERT INTO "BMWMottorad".media VALUES (114, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-4332HsGfCpn8iaUkmGYKQvbinMS9LjVJESEgj4sTd1JPDYT83WTHZtCIYYatnE7kKlnov4bzHTqL8gbwISqM4Cj3hmjDcRW9nZdF5WvHxl08DtlhWaRTs5wX9FlcaIE4WU57QLCH', 19, false);
INSERT INTO "BMWMottorad".media VALUES (115, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-36387Nvq6AmyVBhAH8edq113vi3GpO6IvORbDa1oYG5f1CVWunDgwnchfm0iVov6HFvtUrIJgv0Q6b9qnwg0q5fawteUEuSXpvZKFFABCPbqyTEbnTuv2il4iR7X7Se9YiBfdp6h', 19, false);
INSERT INTO "BMWMottorad".media VALUES (116, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6965xrsuWMo5sX%25lNO3N5rqOK0V0mslcCKfw82ykL02DcJeU2B8YDY5nsbPjewsy2hKc2HMpYKhkcwId04BLuN4N4yQ6LA7GDsgQhZqPbiOdHgXkBiAKlY98BpLGTjoIXjTC6mWs', 19, false);
INSERT INTO "BMWMottorad".media VALUES (117, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-5325pVpX4lHV8VWAS%25Q7waghOwnEcZHiSVai3YoDfuu6CQWVqR7%25IN5fxvVHOa0M793G8cYg0W5enx9T6K4a1LGdts30ulRMOI5oJdapFX5odO9KRr5NKYnixr1xK68YdZk%25a14J', 19, false);
INSERT INTO "BMWMottorad".media VALUES (118, 4, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7422RwK7suqVvQMWZzvnk6TZC8SLNX6hSsc%25kS33R5IaewNwUsYY5NI3PDRdDMjdgapZQdGnXI5bxPt01op9WFz6UmwSHu4MKUUfs523YGyR635QslAdKLx%25GIAiwNfn9%25JG1Hs1', 19, false);
INSERT INTO "BMWMottorad".media VALUES (237, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6042PD1rVGVVrP909ZAqOPWgtSZooxhcFN3ZAq8NXtGVV13OYExVOHYEZdxtNogGMdrWVhtZoo5AqGGMdUXHntFGVV6Md77uIky1%25HhLZoom77uIE9GVVQIGClqj7uIWUKXBGVV5', 44, false);
INSERT INTO "BMWMottorad".media VALUES (276, 3, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-36737GxdBvvSjBsQNaYq%25e1WxEHHRW4IuZp57yXnY344Y0oGvnNcsVeFlx0QTVAfW8EtTVq99QRi6ledVSXRR55ssjYrQvSePm3jS8mBIIfPsjQznKmmFu65AtT7ZwYcJAB5CCB9', 49, false);
INSERT INTO "BMWMottorad".media VALUES (285, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-6343Bj7dT8f7SF8CI1SWEkNdBjtcRukttjv6ir%25PBkfKxnRj3nMAeCf050Bf0wWbMVzISbqNMbkX25O5mZLvCU1kDhnrp8g87DOgnkV0MdVzk0khnJw4ZwtvxH8DTCgWv5EIvCTM', 50, false);
INSERT INTO "BMWMottorad".media VALUES (295, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-49496qu3H0GWW6izvCy4qLpvHtCOZwTvKd%25Cy4tIA7P7HMPqEa830Px2p527dGQ0sBWpNjDCOZY2fpP8LNM0G3KP7HcsB0dS5EjM50T1RDG2PIF6aiP7HZkY2J69qhlC7DAeP7Hy', 52, false);
INSERT INTO "BMWMottorad".media VALUES (305, 28, NULL, 'https://www.bmw-motorrad.fr/imagesrs?COSY-EU-100-7243FBYuLRwY%250RmAt%25c7V1uFB6rQHV66BO2GlixFVw4ZzQBJzWNKmwEaEFwEpc8WfSA%258M1W8VTIakaDXhOm5tVePzlvRnRYeknzVfEWufSVEVPzopsXp6OZ9FSLmncOa7AOmLS', 55, false);


--
-- Data for Name: motodisponible; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".motodisponible VALUES (1, 20931, 1);
INSERT INTO "BMWMottorad".motodisponible VALUES (2, 20984, 3);
INSERT INTO "BMWMottorad".motodisponible VALUES (3, 12094, 2);
INSERT INTO "BMWMottorad".motodisponible VALUES (4, 11098, 4);
INSERT INTO "BMWMottorad".motodisponible VALUES (5, 38591, 4);
INSERT INTO "BMWMottorad".motodisponible VALUES (6, 34872, 2);
INSERT INTO "BMWMottorad".motodisponible VALUES (7, 11487, 3);
INSERT INTO "BMWMottorad".motodisponible VALUES (8, 11248, 2);
INSERT INTO "BMWMottorad".motodisponible VALUES (9, 14875, 3);
INSERT INTO "BMWMottorad".motodisponible VALUES (10, 10487, 1);
INSERT INTO "BMWMottorad".motodisponible VALUES (11, 22895, 4);
INSERT INTO "BMWMottorad".motodisponible VALUES (12, 20855, 1);
INSERT INTO "BMWMottorad".motodisponible VALUES (13, 23574, 4);
INSERT INTO "BMWMottorad".motodisponible VALUES (14, 22584, 3);
INSERT INTO "BMWMottorad".motodisponible VALUES (15, 17463, 3);
INSERT INTO "BMWMottorad".motodisponible VALUES (16, 16584, 2);
INSERT INTO "BMWMottorad".motodisponible VALUES (17, 15685, 4);
INSERT INTO "BMWMottorad".motodisponible VALUES (18, 18754, 1);
INSERT INTO "BMWMottorad".motodisponible VALUES (19, 18584, 3);
INSERT INTO "BMWMottorad".motodisponible VALUES (20, 19584, 2);


--
-- Data for Name: pack; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".pack VALUES (3, 3, 'Pack Race', 'Le pack Race optimise la RR pour les pilotes ambitieux. Le pack comprend la chaîne M Endurance à maintenance réduite et au poids optimisé. Ainsi que le système d’échappement en titane M d’Akrapovič, disponible exclusivement dans le pack, pour un look encore plus sportif avec une nette réduction du poids, ou encore le silencieux sport Slip-on en titane de haute qualité.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3yKHifG70qbX0x1RCzPheU1vGU', 990.00);
INSERT INTO "BMWMottorad".pack VALUES (9, 4, 'Pack Dynamic', 'Le pack Dynamic renforce à la fois la sécurité et la sportivité. Il inclut les modes de conduite Pro, qui vous permettent d’adapter le mode de conduite à chaque situation. L''assistant de changement de rapport Pro renforce encore le contrôle dans les situations inattendues. Le système Dynamic ESA assure la suspension automatique du châssis et vous permet de régler l''intensité du contact entre les pneus et le sol.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3y%25iifG70qbX0x1RCzPheU1vGU', 965.00);
INSERT INTO "BMWMottorad".pack VALUES (4, 1, 'Pack Carbone', 'Le pack carbone haut de gamme complète parfaitement l’aspect Superbike de la machine. Le pack comprend les garde-boues avant et arrière, le protège-chaîne, le couvre-pignon et les flancs de carénage supérieurs. Les fixations dérivées du sport de course en plastique léger renforcé de fibres de carbone ajoutent des touches à la fois élégantes, sportives et High-tech.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3ZvjifGH3dTUw8jgL3hSntD0nBdKVZjYpMdbhM', 2009.00);
INSERT INTO "BMWMottorad".pack VALUES (8, 3, 'Finition Pro', '', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3GrJifG70qbX0x1RCzPheU1vGU', 2200.00);
INSERT INTO "BMWMottorad".pack VALUES (10, 1, 'Pack Confort', 'Le pack idéal pour tous les amateurs de confort. La clé de votre véhicule restera simplement dans votre poche grâce au système Keyless Ride. La régulation électronique de la vitesse permet de rouler à vitesse constante. Le porte-bagages permet de fixer simplement votre topcase. La préparation pour la navigation avec fixation et Mount Cradle pour le combiné d''instruments intègre parfaitement le BMW ConnectedRide Navigator au poste de conduite, dans le champ de vision direct du pilote. Par ailleurs, la chaîne M Endurance réduit le travail de maintenance sur la roue arrière.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3y%25eifG70qbX0x1RCzPheU1vGU', 1000.00);
INSERT INTO "BMWMottorad".pack VALUES (11, 2, 'Pack Confort', 'Le pack Comfort rend les longs trajets encore plus agréables. Grâce au régulateur de vitesse et au prééquipement pour le système de navigation, vous rejoindrez à coup sûr et dans le confort votre destination. Les supports pour valises ouvrent des options flexibles pour le transport des bagages. La chaîne M Endurance réduit le besoin de maintenance. Le système Keyless Ride est une autre fonction pratique à bord.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3y%25eifG70qbX0x1RCzPheU1vGU', 1000.00);
INSERT INTO "BMWMottorad".pack VALUES (5, 2, 'M Billet Pack', 'Le pack de pièces fraisées M souligne le caractère sportif de la moto avec des composants de grande qualité et le marquage M exclusif. Le pack comprend des pièces fraisées en aluminium anodisé, dont des leviers d’embrayage et de frein à main rabattables et réglables, avec Brake Lever Guard – des équipements d’une valeur maximale.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3ZvKifG70qbX0x1RCzPheU1vGU', 425.00);
INSERT INTO "BMWMottorad".pack VALUES (1, 4, 'Pack M', 'Le Pack M accentue le profil sportif de la RR. La peinture exclusive Light white uni/M Motorsport est comprise uniquement dans ce pack et confère un look puissant à la moto. Le pack comprend : la selle sport M pour un maintien optimal et la chasse aux millisecondes décisives. Les roues M Carbon allégées avec bandes M, pour une dynamique de marche maximale. Ou encore les jantes forgées M au choix. En outre, le repose-pieds M et le bouchon de réservoir noir.  ', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZMY2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCR2kgYrt35e1xhZ8XgiAsji7UmvhE0VlU3Xl', 4640.00);
INSERT INTO "BMWMottorad".pack VALUES (7, 4, 'Pack Confort', 'Le Pack Confort est synonyme de confort de première classe pendant les balades et comprend les composants suivants : Shifter Pro, Keyless Ride, verrouillage centralisé et alarme antivol. Il s’agit d’options techniques innovantes dont le pilote exigeant et amateur de Touring ne voudra certainement plus se passer.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3y%25eifG70qbX0x1RCzPheU1vGU', 1590.00);
INSERT INTO "BMWMottorad".pack VALUES (12, 2, 'Pack Dynamic', 'Le pack Dynamic renforce les qualités sportives de la machine, aussi bien sur route qu’en tout-terrain, et apporte en même temps une plus grande sécurité. Les modes de conduite Pro adaptent la moto à la situation de conduite. L’assistant de changement de rapport Pro déleste le pilote et accroît le dynamisme. Mais ce n’est pas tout : le châssis semi-actif Dynamic ESA est aussi de la partie.', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3y%25iifG70qbX0x1RCzPheU1vGU', 1490.00);
INSERT INTO "BMWMottorad".pack VALUES (2, 3, 'Pack Dynamic', 'Le pack Dynamic accentue les qualités de course de la RR pour plus de performance et de confort. Le pack comprend le châssis électronique DDC exclusif adapté au sport automobile pour un amortissement optimal et un contact optimal avec la chaussée dans toutes les situations de conduite. Ainsi que les modes de conduite Pro avec 3 modes de conduite Race Pro supplémentaires et d’autres réglages pertinents pour le circuit tels que Launch Control, Pit-Lane-Limiter, Wheeling Control et Brake Slide Assist, Slide Control. Le régulateur de vitesse électronique et les poignées chauffantes sont également inclus. ', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZTg2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3y%25iifG70qbX0x1RCzPheU1vGU', 1490.00);
INSERT INTO "BMWMottorad".pack VALUES (6, 1, 'Pack Touring', 'Avec le pack Touring, même les longs voyages deviennent des moments de détente. Notamment grâce au système audio 2.0 avec DAB+, égaliseur et réglages audio avancés. La sécurité n’est pas en reste grâce à l’étrier de protection moteur et les projecteurs additionnels à LED', 'https://prod.cosy.bmw.cloud/h5nbc/cosySec?COSY-EU-100-7331c9Nv2Z7d5y07eRUQlPw7CcVxEaZQj2uzHVPRdgShtDoJE470jR5gswTZdk4%25rxlzK%25yoKG3eTOnvzfAxPs8%25P6P1LSClgpnQ3Qd19m9suNXQ2GEDzfHscCw29cvc3GtFifG70qbX0x1RCzPheU1vGU', 875.00);


--
-- Data for Name: parametres; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".parametres VALUES ('montantfraislivraison', '120');
INSERT INTO "BMWMottorad".parametres VALUES ('fraislivraison', '9');


--
-- Data for Name: password_reset_tokens; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".password_reset_tokens VALUES ('simon@gmail.com', '$2y$12$vldlWt.7Tkd13v3/YQdtXOvX6FdyIauzNrXTpAQXN7YOEGIC16h4e', '2023-11-20 12:48:00');
INSERT INTO "BMWMottorad".password_reset_tokens VALUES ('simona@gmail.com', '$2y$12$P3KoLTX6Hsz68sTHNUJZjupM76a7KqMZCR5Q.JDomfXWzc6deehtW', '2023-11-21 16:07:36');
INSERT INTO "BMWMottorad".password_reset_tokens VALUES ('sg.bonneville@gmail.com', '$2y$12$tgQsUn3wfATrEvz97ZT25.Zv8wqlJYyxKLfIcKDUtXEl7RlnzvtJS', '2024-01-08 08:18:52');


--
-- Data for Name: t_r_prefere_prf; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (1, 1);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (2, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (3, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (4, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (5, 5);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (6, 1);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (7, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (8, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (9, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (10, 5);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (11, 1);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (12, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (13, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (14, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (15, 5);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (16, 1);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (17, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (18, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (19, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (20, 5);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (21, 1);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (22, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (23, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (24, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (25, 5);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (26, 1);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (27, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (28, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (29, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (30, 5);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (31, 1);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (32, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (33, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (34, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (35, 5);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (36, 1);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (37, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (38, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (39, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (40, 5);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (41, 1);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (42, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (43, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (44, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (45, 5);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (46, 1);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (47, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (48, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (49, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (50, 5);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (1, 2);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (1, 3);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (1, 4);
INSERT INTO "BMWMottorad".t_r_prefere_prf VALUES (1, 5);


--
-- Data for Name: t_e_prive_prv; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (41, 53);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (42, 55);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (44, 61);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (43, 56);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (48, 65);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (50, 67);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (51, 68);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (52, 69);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (54, 73);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (57, 78);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (58, 79);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (60, 81);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (80, 92);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (81, 93);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (82, 95);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (83, 96);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (84, 97);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (85, 98);
INSERT INTO "BMWMottorad".t_e_prive_prv VALUES (200, 201);


--
-- Data for Name: t_e_professionnel_pro; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_professionnel_pro VALUES (17, 72, 'Turconi Billlionaire');
INSERT INTO "BMWMottorad".t_e_professionnel_pro VALUES (18, 75, 'Simon Cusonnant');
INSERT INTO "BMWMottorad".t_e_professionnel_pro VALUES (12, 52, 'Iut Annecy');
INSERT INTO "BMWMottorad".t_e_professionnel_pro VALUES (20, 90, 'EPSTEIN IS SO COOL');
INSERT INTO "BMWMottorad".t_e_professionnel_pro VALUES (21, 91, 'EPSTEIN IS SO COOL');
INSERT INTO "BMWMottorad".t_e_professionnel_pro VALUES (22, 94, 'PPPASSSSSCAAAAAL');
INSERT INTO "BMWMottorad".t_e_professionnel_pro VALUES (100, 200, 'SUPERBARBE');


--
-- Data for Name: t_e_reservation_res; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (1, 2, 1, 1, '2023-10-21', 'Comptant');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (2, 6, 3, 1, '2023-09-12', 'LLD');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (3, 7, 24, 1, '2023-01-13', 'LLD');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (4, 8, 26, 2, '2023-01-17', 'Crédit');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (5, 13, 33, 2, '2023-02-19', 'LLD');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (6, 14, 35, 2, '2023-01-12', 'Crédit');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (7, 16, 36, 3, '2023-02-01', 'Comptant');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (8, 17, 38, 3, '2023-03-03', 'Comptant');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (9, 18, 42, 4, '2023-04-29', 'Comptant');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (10, 19, 43, 5, '2023-03-02', 'Crédit');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (11, 20, 49, 5, '2023-01-19', 'LLD');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (12, 1, 2, 5, '2023-03-19', 'Comptant');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (13, 3, 27, 4, '2022-03-01', 'Crédit');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (14, 4, 31, 4, '2023-08-05', 'Comptant');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (15, 5, 50, 3, '2023-06-23', 'Crédit');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (16, 12, 11, 2, '2023-08-17', 'Crédit');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (17, 11, 17, 2, '2023-09-26', 'Comptant');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (18, 15, 18, 2, '2023-04-10', 'Comptant');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (19, 10, 6, 1, '2023-02-08', 'Comptant');
INSERT INTO "BMWMottorad".t_e_reservation_res VALUES (20, 20, 9, 1, '2023-06-20', 'Crédit');


--
-- Data for Name: t_j_se_compose_scp; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (1, 5);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (1, 3);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (1, 7);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (1, 1);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (2, 3);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (2, 6);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (2, 5);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (2, 4);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (3, 2);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (3, 7);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (3, 5);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (3, 6);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (4, 9);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (4, 1);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (4, 7);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (4, 2);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (5, 7);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (5, 8);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (5, 14);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (6, 17);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (6, 9);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (7, 11);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (7, 3);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (7, 8);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (8, 1);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (8, 5);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (9, 7);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (9, 13);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (10, 6);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (10, 12);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (10, 4);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (11, 20);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (11, 12);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (11, 16);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (12, 7);
INSERT INTO "BMWMottorad".t_j_se_compose_scp VALUES (12, 15);


--
-- Data for Name: t_j_specifie_spe; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_j_specifie_spe VALUES (1, 1);
INSERT INTO "BMWMottorad".t_j_specifie_spe VALUES (3, 2);
INSERT INTO "BMWMottorad".t_j_specifie_spe VALUES (5, 4);
INSERT INTO "BMWMottorad".t_j_specifie_spe VALUES (6, 3);


--
-- Data for Name: t_e_stock_stk; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 1, 17, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 1, 18, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 1, 19, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 1, 20, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 1, 21, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 1, 22, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 2, 22, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 2, 21, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 2, 20, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 2, 19, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 2, 18, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 2, 17, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 2, 16, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 3, 22, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 3, 21, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 3, 20, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 3, 19, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 3, 18, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 3, 17, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 3, 16, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 4, 22, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 4, 21, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 4, 20, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 4, 19, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 4, 18, 1);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 4, 17, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 4, 16, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 5, 22, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 5, 21, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 5, 20, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 5, 19, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 5, 18, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 5, 17, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 5, 16, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 6, 22, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 6, 21, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 6, 20, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 6, 19, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 6, 18, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 6, 17, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 6, 16, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 6, 23, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 6, 24, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 6, 25, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 6, 26, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 6, 27, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 6, 28, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 6, 29, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 5, 23, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 5, 24, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 5, 25, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 5, 26, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 5, 27, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 5, 28, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 5, 29, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 4, 23, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 4, 24, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 4, 25, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 4, 26, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 4, 27, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 4, 28, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 4, 29, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 3, 23, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 3, 24, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 3, 25, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 3, 26, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 3, 27, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 3, 28, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 3, 29, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 2, 23, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 2, 24, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 2, 25, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 2, 26, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 2, 27, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 2, 28, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 2, 29, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 1, 23, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 1, 24, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 1, 25, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 1, 26, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 1, 27, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 1, 28, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (2, 1, 29, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (7, 8, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (7, 9, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (7, 10, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (7, 11, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (7, 12, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (7, 13, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (7, 14, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (7, 15, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 9, 3, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 10, 3, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 11, 3, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 12, 3, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 13, 3, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 14, 3, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 15, 3, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (8, 8, 5, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (8, 9, 5, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (8, 10, 5, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (8, 11, 5, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (8, 12, 5, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (8, 13, 5, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (8, 14, 5, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (8, 15, 5, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (9, 8, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (9, 9, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (9, 10, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (9, 11, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (9, 12, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (9, 13, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (9, 14, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (9, 15, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (11, 16, 1, 0);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (12, 15, 1, 0);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (16, 16, 31, 13);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (17, 16, 1, 47);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (18, 16, 32, 56);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (19, 2, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (19, 3, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (19, 4, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (19, 5, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (19, 6, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 3, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 5, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 6, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 7, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 2, 2, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 3, 2, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 4, 2, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 5, 2, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 6, 2, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 7, 2, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (20, 2, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (20, 3, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (20, 4, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (20, 5, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (20, 6, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (21, 2, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (5, 8, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (5, 9, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (5, 10, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (5, 11, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (5, 12, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (5, 13, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (5, 14, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (5, 15, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 4, 1, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (21, 3, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (21, 4, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (21, 5, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (21, 6, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (4, 2, 1, 1);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (10, 16, 1, 24);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (23, 2, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (23, 3, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (23, 4, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (23, 5, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (23, 6, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 1, 18, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 1, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 1, 22, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 1, 33, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 1, 34, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 1, 35, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 1, 36, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 2, 18, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 2, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 2, 22, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 2, 33, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 2, 34, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 2, 35, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 2, 36, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 3, 18, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 3, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 3, 22, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 3, 33, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 3, 34, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 3, 35, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 3, 36, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 4, 18, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 4, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 4, 22, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 4, 33, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 4, 34, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 4, 35, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 4, 36, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 5, 18, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 5, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 5, 22, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 5, 33, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 5, 34, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 5, 35, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 5, 36, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 6, 18, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 6, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 6, 22, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 6, 33, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 6, 34, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 6, 35, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (3, 6, 36, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 1, 15, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 1, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 1, 24, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 1, 37, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 1, 39, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 2, 15, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 2, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 2, 24, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 2, 37, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 2, 39, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 3, 15, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 3, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 3, 24, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 3, 37, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 3, 39, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 4, 15, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 4, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 4, 24, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 4, 37, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 4, 39, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 5, 15, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 5, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 5, 24, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 5, 37, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 5, 39, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 6, 15, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 6, 19, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 6, 24, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 6, 37, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 6, 39, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 18, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 19, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 20, 1, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 21, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 22, 1, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 23, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 24, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 25, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 26, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 27, 1, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 28, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 29, 1, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 30, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 18, 30, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 19, 30, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 20, 30, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 21, 30, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 22, 30, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 23, 30, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 24, 30, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 25, 30, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 26, 30, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 27, 30, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 28, 30, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 29, 30, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (13, 30, 30, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (14, 21, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (14, 22, 1, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (14, 23, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (14, 24, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (14, 25, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (14, 26, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (14, 27, 1, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (14, 28, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (14, 29, 1, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (14, 30, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 18, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 19, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 20, 1, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 21, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 22, 1, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 23, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 24, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 25, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 26, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 27, 1, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 28, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 29, 1, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 30, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 18, 13, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 19, 13, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 20, 13, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 21, 13, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 22, 13, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 23, 13, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 24, 13, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 25, 13, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 26, 13, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 27, 13, 8);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 28, 13, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 29, 13, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (15, 30, 13, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (22, 28, 13, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (22, 30, 13, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (22, 32, 13, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (22, 34, 13, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (22, 36, 13, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (22, 40, 13, 1);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (22, 42, 13, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (24, 28, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (24, 30, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (24, 32, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (24, 34, 1, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (24, 36, 1, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (24, 40, 1, 1);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (24, 42, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (25, 45, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (25, 46, 1, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (25, 47, 1, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (25, 48, 1, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (25, 49, 1, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (25, 50, 1, 1);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (25, 51, 1, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (26, 45, 6, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (26, 46, 6, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (26, 47, 6, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (26, 48, 6, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (26, 49, 6, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (26, 50, 6, 1);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (26, 51, 6, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (27, 45, 6, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (27, 46, 6, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (27, 47, 6, 3);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (27, 48, 6, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (27, 49, 6, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (27, 50, 6, 1);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (27, 51, 6, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 8, 4, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 9, 4, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 10, 4, 4);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 11, 4, 10);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 12, 4, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 13, 4, 2);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 14, 4, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 15, 4, 5);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 1, 38, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 2, 38, 12);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 3, 38, 14);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 4, 38, 16);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 5, 38, 7);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (28, 6, 38, 6);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (1, 1, 16, 15);
INSERT INTO "BMWMottorad".t_e_stock_stk VALUES (6, 8, 3, 10);


--
-- Data for Name: t_e_telephone_tel; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (135, 75, '0669426968', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (136, 75, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (137, 75, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (138, 75, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (200, 90, '0758493859', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (201, 90, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (202, 90, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (203, 90, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (204, 91, '0123456789', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (205, 91, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (206, 91, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (207, 91, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (147, 78, '0658457844', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (148, 78, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (149, 78, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (150, 78, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (208, 92, '0758493859', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (209, 92, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (210, 92, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (211, 92, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (212, 93, '0758493958', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (213, 93, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (214, 93, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (215, 93, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (216, 94, '0959823749', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (217, 94, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (218, 94, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (219, 94, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (220, 95, '0695882737', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (221, 95, '0858723658', 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (127, 72, '0783231325', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (128, 72, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (129, 72, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (130, 72, '0558675857', 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (55, 52, '0678894556', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (56, 52, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (57, 52, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (58, 52, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (59, 53, '0695892327', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (60, 53, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (61, 53, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (62, 53, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (67, 55, '0695892327', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (68, 55, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (69, 55, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (70, 55, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (71, 56, '0695892327', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (72, 56, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (73, 56, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (74, 56, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (83, 61, '0679491933', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (84, 61, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (85, 61, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (86, 61, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (222, 95, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (223, 95, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (224, 96, '0785426516', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (225, 96, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (99, 65, '0646190020', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (100, 65, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (101, 65, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (102, 65, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (107, 67, '0658487512', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (108, 67, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (109, 67, '0758421545', 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (110, 67, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (111, 68, '0612345678', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (112, 68, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (113, 68, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (114, 68, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (115, 69, '0404040404', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (116, 69, '0606060606', 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (117, 69, '0404040404', 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (118, 69, '0606060606', 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (131, 73, '0783231325', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (132, 73, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (133, 73, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (134, 73, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (226, 96, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (227, 96, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (228, 97, '0784561651', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (229, 97, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (151, 79, '0544848484', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (152, 79, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (153, 79, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (154, 79, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (159, 81, '0258695842', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (160, 81, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (161, 81, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (162, 81, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (230, 97, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (231, 97, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (232, 98, '0789451213', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (233, 98, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (234, 98, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (235, 98, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (400, 200, '0541214154', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (401, 200, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (402, 200, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (403, 200, NULL, 'Fixe', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (404, 201, '0783252154', 'Mobile', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (405, 201, NULL, 'Mobile', 'Professionnel');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (406, 201, NULL, 'Fixe', 'Privé');
INSERT INTO "BMWMottorad".t_e_telephone_tel VALUES (407, 201, NULL, 'Fixe', 'Professionnel');


--
-- Data for Name: t_h_transaction_tct; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (6, 129, 'CB', -599.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (7, 130, 'CB', -599.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (10, 131, 'CB', -1209.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (11, 131, 'remboursement', 1200.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (12, 132, 'CB', -2360.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (13, 133, 'CB', -2360.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (14, 131, 'remboursement', 1600.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (15, 131, 'remboursement', 7280.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (17, 131, 'remboursement', 393.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (22, 134, 'CB', -3549.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (23, 134, 'remboursement', 3540.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (24, 135, 'CB', -590.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (25, 136, 'CB', 570.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (26, 137, 'CB', 1540.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (27, 138, 'CB', 591.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (28, 139, 'CB', 79.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (29, 130, 'remboursement', -591.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (1, 200, 'stripe', 590.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (2, 200, 'remboursement', -590.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (3, 132, 'remboursement', -2360.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (4, 400, 'CB', 590.00);
INSERT INTO "BMWMottorad".t_h_transaction_tct VALUES (5, 401, 'CB', 990.00);


--
-- Data for Name: t_e_users_usr; Type: TABLE DATA; Schema: BMWMottorad; Owner: s225
--

INSERT INTO "BMWMottorad".t_e_users_usr VALUES (26, 'sans', 'sanscommande@gmail.com', '$2y$12$BL8Jx4VFNrPc0ZKGHHVvRec9oZw/BfljIFamfBeGld2CFTP.oVr0m', '2023-12-19', '2023-12-19', 'M', 'commande', 78, true, 0, false, '2023-12-19');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (23, 'Simon', 'levraisimoncussonait@gmail.com', '$2y$12$THw2pTRDXELveHxEIskWROQefPZAPGA/w4i1xRPTct09xa0YLVSyy', '2023-12-18', '2023-12-18', 'M', 'Cussonait', 75, true, 0, false, '2023-12-18');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (27, 'avec', 'avecommande@gmail.com', '$2y$12$BLIJizwO470Dp5wvT0P3iuUhZN/QHydmfAG78oXqTKEnixaf6q8PK', '2023-12-19', '2023-12-19', 'M', 'commande', 79, true, 0, false, '2023-12-19');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (29, 'avec', 'avec@gmail.com', '$2y$12$bTo3ixRYKFwmD.AtpYd0tuIyPLriJYr2XKqUAP4qpZ4Yfzq2BXZHK', '2023-12-19', '2023-12-19', 'M', 'avec', 81, true, 0, false, '2023-12-19');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (2, 'Pascal', 'pascal.colin@gmail.com', '$2y$12$xBBqpQNKYgoAwSZdmomOyOBnkDLtZOlM07CVM9HocAX5v25oSGc.q', '2023-11-29', '2023-11-29', 'M', 'Colin', 52, true, 0, false, '2023-12-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (4, 'Simon', 'simon@gmail.com', '$2y$12$sK6ivkA80r2TzzkKcG0NjO5StEkAerRWoYOiHFQ1GPzS77TmyYNkm', '2023-12-04', '2023-12-04', 'M', 'Shoah', 53, true, 0, false, '2023-12-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (6, 'Simon', 'simon@bmw.com', '$2y$12$iPnj1mRbFCT9yggWKG7j.uY5Zgpq5yL0cp2r0urcCcVxT.2t3KxOm', '2023-12-05', '2023-12-05', 'M', 'GOY', 55, true, 0, false, '2023-12-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (7, 'Simon', 'sg.bonneville@gmail.com', '$2y$12$uunUPF07m0onE/iZUugJaOqp996SUXPlX3LYNcC0b7IlzS.Gyag.y', '2023-12-07', '2023-12-07', 'M', 'GOY', 56, true, 0, false, '2023-12-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (10, 'Helène', 'helene.carter@gmail.com', '$2y$12$ZLYS55juwUdkWGqxGeAQT.bqC.w9o37cXBmPmLqtwqSqHaDEMP0xC', '2023-12-08', '2023-12-08', 'Mme', 'Carter', 61, true, 0, false, '2023-12-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (16, 'Arturo', 'arturo@gmail.com', '$2y$12$TJJ7Pn3JZjd905i4eyV51ej8vO4lXj8.VZrcY3uDEYC1k7ILAKXwS', '2023-12-13', '2023-12-13', 'M', 'Turconito', 67, true, 0, false, '2023-12-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (18, 'Réparez le site plz', 'css_404_not_found@iutannecy-deptinfo.fr', '$2y$12$OChrw0GCiW2/Z97t7llS0u6nUyvLpTgitEtdOKhTpNA.eiuF3F/6u', '2023-12-13', '2023-12-13', 'M', 'CPT', 69, true, 0, false, '2023-12-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (14, 'Anna', 'anna.kompaniets@gmail.com', '$2y$12$IW0yv6maV.kMfzFnY038vuL1CtQGhba221n0C6gnhgL4tDLhP8b42', '2023-12-11', '2023-12-11', 'M', 'Kompaniets', 65, true, 0, false, '2023-12-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (21, 'Arthur', 'arthur.turconi@gmail.com', '$2y$12$1lG0xwFrM0ToPypxuuCW8eX1rr4fufmwIGj9ObrzvkwQ5xZ0TWJMC', '2023-12-13', '2023-12-19', 'M', 'Turconi', 72, true, 0, true, '2023-12-19');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (22, 'DPO', 'dpo@bmwmottorad.com', '$2y$12$XMnSYjHsQyL8mwpjLcliv.7.PGyomdbP.QuG41zrGKiS5gLWK.L8e', '2023-12-15', '2024-01-09', 'M', 'DPO', 73, true, 2, false, '2024-01-09');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (1, 'Epstein', 'epstein@gmail.com', '$2y$12$l1VhYQ5TBR8yzuhgnX/pau0hXDOfYZfPJdo0pmt20HZ4EmimhKYU2', '2024-01-10', '2024-01-10', 'M', 'Island', 90, true, 0, false, '2024-01-10');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (40, 'Barbapapa', 'barbapapa@gmail.com', '$2y$12$9PfkXcCM93c.3Lvwf2SH/uCLc0hpCunMuwr4erm7xJOIim8DCk1We', '2024-01-15', '2024-01-15', 'M', 'BarbaFamille', 200, true, 0, false, '2024-01-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (17, 'Commerce', 'commerce@bmw.fr', '$2y$12$KUrKM0qJinlvy1xl5jVfeOWr8.K4jOyMTXQzpCgGp8R6jv.bw9H5S', '2023-12-13', '2024-01-14', 'M', 'Commerce', 68, true, 1, false, '2024-01-14');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (3, 'Simon', 'simon.cussonait@gmail.com', '$2y$12$UFeLFhns1P0t2o7hT.0IGO2nFpNa4ZUxM3h2svIln7OBLCsfpyb4C', '2024-01-14', '2024-01-14', 'M', 'Cussonait', 91, true, 0, false, '2024-01-14');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (5, 'Stephen', 'stephenh@gmail.com', '$2y$12$/XUw9DXhDgs5OFAtOmDX.u07tIgIjvg80W1OqR8H2a25MOYIMA3yG', '2024-01-14', '2024-01-14', 'M', 'Hawking', 92, true, 0, false, '2024-01-14');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (8, 'Homme', 'paddle@gmail.com', '$2y$12$bxwtT4GVrmAdvGQ9ed1zm.cJFOiztCAy/MwakjnPszyC2tVPrNq2e', '2024-01-14', '2024-01-14', 'M', 'Paddle', 93, true, 0, false, '2024-01-14');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (9, 'pascaline', 'pascaline@coline.fr', '$2y$12$FWapdxZ2yJs1Ew0dSfjp2evBOTWIkUGq./uiyHQbiTY6HqWaObaoO', '2024-01-14', '2024-01-14', 'Mme', 'coline', 94, true, 0, false, '2024-01-14');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (11, 'Dylan', 'dydylan@gmail.com', '$2y$12$GAC8gCTt5aH.HuzhRtDWXOjORnIsFB/Umo2gBAmNy1gqbV6THrdCa', '2024-01-14', '2024-01-14', 'M', 'Milftari', 95, true, 0, false, '2024-01-14');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (12, 'Prenomtest', 'prenom.nom@gmail.com', '$2y$12$0W5tiLtDtO1Glpp1ldCJwu4ssVSxBYIAfjdVENBwOh1g1hnJWK2uS', '2024-01-15', '2024-01-15', 'M', 'Nomtest', 96, true, 0, false, '2024-01-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (13, 'ZOUZOU', 'zouzou@gmail.com', '$2y$12$FhQMv53v.yQefDGygh.4SO5qEzCFjxOVtYMB0X80v29JkjzUkpQXO', '2024-01-15', '2024-01-15', 'M', 'ZAZA', 97, true, 0, false, '2024-01-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (15, 'Barack', 'barack@maisonblanche.fr', '$2y$12$y2hoGAlJNCNsRJ1A.2R.gucljzCngiGQCwBVzxVhAcxYgutSm6VKa', '2024-01-15', '2024-01-15', 'M', 'Obmana', 98, true, 0, false, '2024-01-15');
INSERT INTO "BMWMottorad".t_e_users_usr VALUES (41, 'Simon', 'simon.pasgay@gmail.com', '$2y$12$DKszpP7jW53GJgG7LAoKIur3.qf5nzxdnXDBotaGdmRZJTg9E6Sgu', '2024-01-15', '2024-01-15', 'M', 'PasGay', 201, true, 0, false, '2024-01-15');


--
-- Name: accessoire_idaccessoire_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".accessoire_idaccessoire_seq', 1, false);


--
-- Name: adresse_numadresse_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".adresse_numadresse_seq', 201, true);


--
-- Name: caracteristique_idcaracteristique_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".caracteristique_idcaracteristique_seq', 1, false);


--
-- Name: t_e_categorieaccessoire_cta_idcatacc_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".t_e_categorieaccessoire_cta_idcatacc_seq', 1, false);


--
-- Name: categoriecaracteristique_idcatcaracteristique_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".categoriecaracteristique_idcatcaracteristique_seq', 1, false);


--
-- Name: categorieequipement_idcatequipement_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".categorieequipement_idcatequipement_seq', 1, false);


--
-- Name: client_idclient_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".client_idclient_seq', 201, true);


--
-- Name: collection_idcollection_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".collection_idcollection_seq', 1, false);


--
-- Name: coloris_idcoloris_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".coloris_idcoloris_seq', 1, false);


--
-- Name: commande_idcommande_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".commande_idcommande_seq', 401, true);


--
-- Name: concessionnaire_idconcessionnaire_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".concessionnaire_idconcessionnaire_seq', 1, false);


--
-- Name: contactinfo_idcontact_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".contactinfo_idcontact_seq', 61, true);


--
-- Name: couleur_idcouleur_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".couleur_idcouleur_seq', 1, false);


--
-- Name: demandeessai_iddemandessai_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".demandeessai_iddemandessai_seq', 20, true);


--
-- Name: equipement_idequipement_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".equipement_idequipement_seq', 1, false);


--
-- Name: t_e_gammemoto_gam_idgamme_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".t_e_gammemoto_gam_idgamme_seq', 1, false);


--
-- Name: infocb_idcarte_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".infocb_idcarte_seq', 20, true);


--
-- Name: media_idmedia_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".media_idmedia_seq', 1, false);


--
-- Name: t_e_modelemoto_mod_idmoto_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".t_e_modelemoto_mod_idmoto_seq', 1, false);


--
-- Name: motoconfigurable_idmotoconfigurable_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".motoconfigurable_idmotoconfigurable_seq', 1, false);


--
-- Name: motodisponible_idmotodisponible_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".motodisponible_idmotodisponible_seq', 1, false);


--
-- Name: offre_idoffre_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".offre_idoffre_seq', 1, false);


--
-- Name: option_idoption_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".option_idoption_seq', 1, false);


--
-- Name: pack_idpack_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".pack_idpack_seq', 1, false);


--
-- Name: presentation_eq_idpresentation_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".presentation_eq_idpresentation_seq', 1, false);


--
-- Name: prive_idprive_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".prive_idprive_seq', 200, true);


--
-- Name: professionnel_idpro_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".professionnel_idpro_seq', 100, true);


--
-- Name: reservation_idreservation_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".reservation_idreservation_seq', 1, false);


--
-- Name: style_idstyle_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".style_idstyle_seq', 1, false);


--
-- Name: taille_idtaille_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".taille_idtaille_seq', 1, false);


--
-- Name: telephone_idtelephone_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".telephone_idtelephone_seq', 407, true);


--
-- Name: transaction_idtransaction_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".transaction_idtransaction_seq', 5, true);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: BMWMottorad; Owner: s225
--

SELECT pg_catalog.setval('"BMWMottorad".users_id_seq', 41, true);


--
-- PostgreSQL database dump complete
--

