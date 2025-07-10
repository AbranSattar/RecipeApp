INSERT INTO tblCountry (Country) VALUES
('Afghanistan'),
('Albania'),
('Algeria'),
('Andorra'),
('Angola'),
('Antigua and Barbuda'),
('Argentina'),
('Armenia'),
('Australia'),
('Austria'),
('Azerbaijan'),
('Bahamas'),
('Bahrain'),
('Bangladesh'),
('Barbados'),
('Belarus'),
('Belgium'),
('Belize'),
('Benin'),
('Bhutan'),
('Bolivia'),
('Bosnia and Herzegovina'),
('Botswana'),
('Brazil'),
('Brunei'),
('Bulgaria'),
('Burkina Faso'),
('Burundi'),
('Cabo Verde'),
('Cambodia'),
('Cameroon'),
('Canada'),
('Central African Republic'),
('Chad'),
('Chile'),
('China'),
('Colombia'),
('Comoros'),
('Congo'),
('Costa Rica'),
('Croatia'),
('Cuba'),
('Cyprus'),
('Czech Republic'),
('Denmark'),
('Djibouti'),
('Dominica'),
('Dominican Republic'),
('Ecuador'),
('Egypt'),
('El Salvador'),
('Equatorial Guinea'),
('Eritrea'),
('Estonia'),
('Eswatini'),
('Ethiopia'),
('Fiji'),
('Finland'),
('France'),
('Gabon'),
('Gambia'),
('Georgia'),
('Germany'),
('Ghana'),
('Greece'),
('Grenada'),
('Guatemala'),
('Guinea'),
('Guinea-Bissau'),
('Guyana'),
('Haiti'),
('Honduras'),
('Hungary'),
('Iceland'),
('India'),
('Indonesia'),
('Iran'),
('Iraq'),
('Ireland'),
('Israel'),
('Italy'),
('Jamaica'),
('Japan'),
('Jordan'),
('Kazakhstan'),
('Kenya'),
('Kiribati'),
('Kuwait'),
('Kyrgyzstan'),
('Laos'),
('Latvia'),
('Lebanon'),
('Lesotho'),
('Liberia'),
('Libya'),
('Liechtenstein'),
('Lithuania'),
('Luxembourg'),
('Madagascar'),
('Malawi'),
('Malaysia'),
('Maldives');

INSERT INTO tblRole (Role)
VALUES 
('Admin'),
('Chef'),
('User')
;
INSERT INTO tblRegion (CountryID, Area)
VALUES 
(1, 'Kabul'),
(1, 'Herat'),
(2, 'Tirana'),
(2, 'Shkodër'),
(3, 'Algiers'),
(3, 'Oran'),
(4, 'Andorra la Vella'),
(5, 'Luanda'),
(5, 'Benguela'),
(6, 'Saint John’s'),
(7, 'Buenos Aires'),
(7, 'Cordoba'),
(8, 'Yerevan'),
(9, 'Sydney'),
(9, 'Melbourne'),
(9, 'Brisbane'),
(10, 'Vienna'),
(10, 'Salzburg'),
(11, 'Baku'),
(12, 'Nassau'),
(12, 'Freeport'),
(13, 'Manama'),
(14, 'Dhaka'),
(14, 'Chittagong'),
(15, 'Bridgetown'),
(16, 'Minsk'),
(16, 'Grodno'),
(17, 'Brussels'),
(17, 'Antwerp'),
(18, 'Belmopan'),
(19, 'Porto-Novo'),
(19, 'Cotonou'),
(20, 'Thimphu'),
(21, 'La Paz'),
(21, 'Santa Cruz'),
(22, 'Sarajevo'),
(22, 'Mostar'),
(23, 'Gaborone'),
(23, 'Francistown'),
(24, 'Rio de Janeiro'),
(24, 'São Paulo'),
(24, 'Brasília'),
(25, 'Bandar Seri Begawan'),
(26, 'Sofia'),
(26, 'Varna'),
(27, 'Ouagadougou'),
(27, 'Bobo-Dioulasso'),
(28, 'Bujumbura'),
(29, 'Praia'),
(30, 'Phnom Penh'),
(30, 'Siem Reap'),
(31, 'Yaoundé'),
(31, 'Douala'),
(32, 'Toronto'),
(32, 'Vancouver'),
(32, 'Montreal'),
(33, 'Bangui'),
(34, 'N’Djamena'),
(34, 'Moundou'),
(35, 'Santiago'),
(35, 'Valparaíso'),
(36, 'Beijing'),
(36, 'Shanghai'),
(36, 'Guangzhou'),
(37, 'Bogotá'),
(37, 'Medellín'),
(38, 'Moroni'),
(39, 'Brazzaville'),
(39, 'Pointe-Noire'),
(40, 'San José'),
(40, 'Limón'),
(41, 'Zagreb'),
(41, 'Split'),
(42, 'Havana'),
(43, 'Nicosia'),
(44, 'Prague'),
(44, 'Brno'),
(45, 'Copenhagen'),
(45, 'Aarhus'),
(46, 'Djibouti City'),
(47, 'Roseau'),
(48, 'Santo Domingo'),
(48, 'Santiago'),
(49, 'Quito'),
(49, 'Guayaquil'),
(50, 'Cairo'),
(50, 'Alexandria'),
(51, 'San Salvador'),
(52, 'Malabo'),
(53, 'Asmara'),
(54, 'Tallinn'),
(55, 'Mbabane'),
(56, 'Addis Ababa'),
(56, 'Dire Dawa'),
(57, 'Suva'),
(58, 'Helsinki'),
(58, 'Tampere'),
(59, 'Paris'),
(59, 'Marseille'),
(60, 'Libreville'),
(61, 'Banjul'),
(62, 'Tbilisi'),
(63, 'Berlin'),
(63, 'Munich'),
(63, 'Hamburg'),
(64, 'Accra'),
(65, 'Athens'),
(65, 'Thessaloniki'),
(66, 'Saint George’s'),
(67, 'Guatemala City'),
(68, 'Conakry'),
(69, 'Bissau'),
(70, 'Georgetown'),
(71, 'Port-au-Prince'),
(72, 'Tegucigalpa'),
(73, 'Budapest'),
(73, 'Debrecen'),
(74, 'Reykjavik'),
(75, 'New Delhi'),
(75, 'Mumbai'),
(75, 'Chennai'),
(76, 'Jakarta'),
(76, 'Bali'),
(77, 'Tehran'),
(77, 'Isfahan'),
(78, 'Baghdad'),
(78, 'Basra'),
(79, 'Dublin'),
(80, 'Jerusalem'),
(81, 'Rome'),
(81, 'Florence'),
(81, 'Venice'),
(82, 'Kingston'),
(83, 'Tokyo'),
(83, 'Osaka'),
(83, 'Kyoto'),
(84, 'Amman'),
(85, 'Nur-Sultan'),
(85, 'Almaty'),
(86, 'Nairobi'),
(86, 'Mombasa'),
(87, 'Tarawa');

INSERT INTO tblCity (City) VALUES
-- Cities in New Zealand
('Auckland'), ('Wellington'), ('Christchurch'), ('Hamilton'), ('Tauranga'),
('Napier'), ('Dunedin'), ('Palmerston North'), ('Nelson'), ('Rotorua'),
('New Plymouth'), ('Whanganui'), ('Gisborne'), ('Invercargill'), ('Hastings'),
('Whangarei'), ('Timaru'), ('Taupo'), ('Queenstown'), ('Blenheim'),
('Cambridge'), ('Masterton'), ('Levin'), ('Feilding'), ('Te Awamutu'),
('Ashburton'), ('Pukekohe'), ('Gore'), ('Kerikeri'), ('Kaikoura'),
('Greymouth'), ('Waiheke Island'), ('Cromwell'), ('Westport'), ('Matamata'),
('Oamaru'), ('Motueka'), ('Tokoroa'), ('Warkworth'), ('Mangawhai'),
('Putaruru'), ('Waihi'), ('Te Kuiti'), ('Opotiki'), ('Hokitika'),
('Alexandra'), ('Balclutha'), ('Waiuku'), ('Kaitaia'), ('Dargaville'),

-- Cities in Australia
('Sydney'), ('Melbourne'), ('Brisbane'), ('Perth'), ('Adelaide'),
('Gold Coast'), ('Canberra'), ('Hobart'), ('Darwin'), ('Geelong'),
('Newcastle'), ('Wollongong'), ('Cairns'), ('Toowoomba'), ('Townsville'),
('Ballarat'), ('Bendigo'), ('Launceston'), ('Albury'), ('Mackay'),
('Rockhampton'), ('Bunbury'), ('Coffs Harbour'), ('Gladstone'), ('Hervey Bay'),
('Port Macquarie'), ('Wagga Wagga'), ('Tamworth'), ('Traralgon'), ('Whyalla'),
('Kalgoorlie'), ('Alice Springs'), ('Mount Gambier'), ('Burnie'), ('Devonport'),
('Lismore'), ('Shepparton'), ('Sunbury'), ('Orange'), ('Bowral'),
('Dubbo'), ('Bathurst'), ('Goulburn'), ('Warwick'), ('Yeppoon'),
('Emerald'), ('Armidale'), ('Muswellbrook'), ('Cowra'), ('Byron Bay');

INSERT INTO tblSuburb (CityID, Suburb, ZipCode) VALUES
-- Suburbs in New Zealand (CityID 1 to 50)
(1, 'Ponsonby', 1011), (1, 'Mt Eden', 1024), (2, 'Te Aro', 6011), (2, 'Brooklyn', 6021),
(3, 'Fendalton', 8041), (3, 'Riccarton', 8011), (4, 'Frankton', 3204), (4, 'Hillcrest', 3216),
(5, 'Bethlehem', 3110), (5, 'Otumoetai', 3112), (6, 'Ahuriri', 4110), (6, 'Tamatea', 4112),
(7, 'St Clair', 9012), (7, 'Roslyn', 9010), (8, 'Milson', 4414), (8, 'Kelvin Grove', 4412),
(9, 'Atawhai', 7010), (9, 'Tahunanui', 7011), (10, 'Fenton Park', 3010), (10, 'Western Heights', 3015),
(11, 'Welbourn', 4310), (11, 'Fitzroy', 4312), (12, 'St Johns Hill', 4500), (12, 'Castlecliff', 4501),
(13, 'Mangapapa', 4010), (13, 'Kaiti', 4013), (14, 'Waikiwi', 9810), (14, 'Glengarry', 9812),
(15, 'Flaxmere', 4120), (15, 'Parkvale', 4122), (16, 'Kensington', 0112), (16, 'Onerahi', 0110),
(17, 'Highfield', 7910), (17, 'Parkside', 7912), (18, 'Hilltop', 3330), (18, 'Waipahihi', 3332),
(19, 'Sunshine Bay', 9300), (19, 'Fernhill', 9302), (20, 'Springlands', 7201), (20, 'Riverlands', 7202),
(21, 'Leamington', 3432), (21, 'Hautapu', 3434), (22, 'Lansdowne', 5810), (22, 'Solway', 5812),
(23, 'Kawaha Point', 3021), (23, 'Holdens Bay', 3015), (24, 'Fairfield', 3214), (24, 'Flagstaff', 3210),
(25, 'Papamoa Beach', 3118), (25, 'Arataki', 3116), (26, 'Terrace End', 4410), (26, 'Awapuni', 4412),
(27, 'Monaco', 7011), (27, 'Victory', 7010), (28, 'Koutu', 3010), (28, 'Fairy Springs', 3015),
(29, 'Moturoa', 4310), (29, 'Blagdon', 4312), (30, 'Gonville', 4500), (30, 'Durie Hill', 4501),
(31, 'Elgin', 4010), (31, 'Te Hapara', 4013), (32, 'Woodend', 9812), (32, 'Gladstone', 9810),
(33, 'Mahora', 4120), (33, 'Raureka', 4122), (34, 'Regent', 0112), (34, 'Whau Valley', 0110),
(35, 'Oceanview', 7910), (35, 'West End', 7912), (36, 'Acacia Bay', 3330), (36, 'Nukuhau', 3332),
(37, 'Arthurs Point', 9300), (37, 'Shotover Country', 9302), (38, 'Witherlea', 7201), (38, 'Taylor Pass', 7202),
(39, 'Te Mata', 3432), (39, 'Te Miro', 3434), (40, 'Upper Plain', 5810), (40, 'Kuripuni', 5812),

-- Suburbs in Australia (CityID 51 to 100)
(51, 'Bondi', 2026), (51, 'Surry Hills', 2010), (52, 'St Kilda', 3182), (52, 'Fitzroy', 3065),
(53, 'South Brisbane', 4101), (53, 'New Farm', 4005), (54, 'Subiaco', 6008), (54, 'Claremont', 6010),
(55, 'North Adelaide', 5006), (55, 'Semaphore', 5019), (56, 'Broadbeach', 4218), (56, 'Burleigh Heads', 4220),
(57, 'Kingston', 2604), (57, 'Belconnen', 2617), (58, 'Battery Point', 7004), (58, 'Sandy Bay', 7005),
(59, 'Stuart Park', 0820), (59, 'Bayview', 0820), (60, 'East Geelong', 3219), (60, 'Rippleside', 3220),
(61, 'Merewether', 2291), (61, 'The Junction', 2291), (62, 'Figtree', 2525), (62, 'Gwynneville', 2500),
(63, 'Edge Hill', 4870), (63, 'Whitfield', 4870), (64, 'Mount Lofty', 4350), (64, 'East Toowoomba', 4350),
(65, 'West End', 4810), (65, 'North Ward', 4810), (66, 'Lake Wendouree', 3350), (66, 'Golden Point', 3350),
(67, 'White Hills', 3550), (67, 'Kangaroo Flat', 3555), (68, 'West Launceston', 7250), (68, 'Kings Meadows', 7249),
(69, 'East Albury', 2640), (69, 'Lavington', 2641), (70, 'North Mackay', 4740), (70, 'Andergrove', 4740),
(71, 'Frenchville', 4701), (71, 'Allenstown', 4700), (72, 'South Bunbury', 6230), (72, 'East Bunbury', 6230),
(73, 'Boambee', 2450), (73, 'Sawtell', 2452), (74, 'Clinton', 4680), (74, 'Kin Kora', 4680),
(75, 'Urangan', 4655), (75, 'Torquay', 4655), (76, 'Thrumster', 2444), (76, 'Lake Innes', 2446),
(77, 'Kooringal', 2650), (77, 'Mount Austin', 2650), (78, 'Calala', 2340), (78, 'Oxley Vale', 2340),
(79, 'Summerhill', 7250), (79, 'West Launceston', 7249), (80, 'West Whyalla', 5608), (80, 'Whyalla Norrie', 5608);

INSERT INTO tblStore (SuburbID, Store) VALUES
-- Stores in New Zealand (SuburbIDs 1 to 50)
(1, 'Countdown Ponsonby'), (2, 'New World Grey Lynn'), (3, 'PaknSave Te Aro'), (4, 'Countdown Kelburn'),
(5, 'New World Riccarton'), (6, 'Fresh Choice Sumner'), (7, 'Countdown Frankton'), (8, 'PaknSave Hillcrest'),
(9, 'New World Bethlehem'), (10, 'Countdown Greerton'), (11, 'PaknSave Napier South'), (12, 'New World Tamatea'),
(13, 'Countdown St Kilda'), (14, 'Fresh Choice Mornington'), (15, 'New World Milson'), (16, 'Countdown Awapuni'),
(17, 'PaknSave Tahunanui'), (18, 'New World Stoke'), (19, 'Countdown Fenton Park'), (20, 'PaknSave Rotorua Central'),
(21, 'New World Fitzroy'), (22, 'Countdown Westown'), (23, 'PaknSave Castlecliff'), (24, 'Countdown Wembley Park'),
(25, 'New World Mangapapa'), (26, 'PaknSave Whataupoko'), (27, 'Countdown Waikiwi'), (28, 'Fresh Choice Richmond'),
(29, 'PaknSave Parkvale'), (30, 'Countdown Mahora'), (31, 'New World Kensington'), (32, 'PaknSave Regent'),
(33, 'Countdown Highfield'), (34, 'New World Glenwood'), (35, 'PaknSave Hilltop'), (36, 'Countdown Tauhara'),
(37, 'New World Fernhill'), (38, 'PaknSave Sunshine Bay'), (39, 'Countdown Springlands'), (40, 'New World Witherlea'),
(41, 'PaknSave Leamington'), (42, 'Countdown Cambridge Central'), (43, 'New World Masterton Central'), (44, 'Countdown Kuripuni'),
(45, 'PaknSave Fairy Springs'), (46, 'Countdown Ngongotaha'), (47, 'New World Flagstaff'), (48, 'PaknSave Rototuna'),
(49, 'Countdown Papamoa Beach'), (50, 'New World Mount Maunganui'),

-- Stores in Australia (SuburbIDs 51 to 100)
(51, 'Coles Bondi'), (52, 'Woolworths Surry Hills'), (53, 'Coles St Kilda'), (54, 'Woolworths Fitzroy'),
(55, 'Coles New Farm'), (56, 'Woolworths South Brisbane'), (57, 'Coles Claremont'), (58, 'Woolworths Subiaco'),
(59, 'Coles North Adelaide'), (60, 'Woolworths Semaphore'), (61, 'Coles Broadbeach'), (62, 'Woolworths Burleigh Heads'),
(63, 'Coles Kingston'), (64, 'Woolworths Belconnen'), (65, 'Coles Battery Point'), (66, 'Woolworths Sandy Bay'),
(67, 'Coles Stuart Park'), (68, 'Woolworths Bayview'), (69, 'Coles Rippleside'), (70, 'Woolworths East Geelong'),
(71, 'Coles Merewether'), (72, 'Woolworths The Junction'), (73, 'Coles Figtree'), (74, 'Woolworths Gwynneville'),
(75, 'Coles Edge Hill'), (76, 'Woolworths Whitfield'), (77, 'Coles East Toowoomba'), (78, 'Woolworths Mount Lofty'),
(79, 'Coles North Ward'), (80, 'Woolworths West End'), (81, 'Coles Lake Wendouree'), (82, 'Woolworths Golden Point'),
(83, 'Coles Kangaroo Flat'), (84, 'Woolworths White Hills'), (85, 'Coles Kings Meadows'), (86, 'Woolworths South Launceston'),
(87, 'Coles Lavington'), (88, 'Woolworths East Albury'), (89, 'Coles North Mackay'), (90, 'Woolworths Andergrove'),
(91, 'Coles Allenstown'), (92, 'Woolworths Frenchville'), (93, 'Coles South Bunbury'), (94, 'Woolworths Eaton'),
(95, 'Coles Sawtell'), (96, 'Woolworths Boambee'), (97, 'Coles Clinton'), (98, 'Woolworths Kin Kora'),
(99, 'Coles Urangan'), (100, 'Woolworths Point Vernon');

INSERT INTO tblUser (FirstName, LastName, Email, UserName, RoleID, Password) VALUES
('Gordon', 'Ramsay', 'gordon.ramsay@example.com', 'gordonr', 1, 'a8X3zBqP'),
('Jamie', 'Oliver', 'jamie.oliver@example.com', 'jamieo', 2, 'P4k9yLsm'),
('Nigella', 'Lawson', 'nigella.lawson@example.com', 'nigellal', 3, 'W7tQs0nJ'),
('Heston', 'Blumenthal', 'heston.blumenthal@example.com', 'hestonb', 1, 'u9Hd3LkR'),
('Yotam', 'Ottolenghi', 'yotam.ottolenghi@example.com', 'yotamo', 2, 'Z3jNr5vX'),
('Thomas', 'Keller', 'thomas.keller@example.com', 'thomask', 3, 'm1Sf8XyP'),
('Alice', 'Waters', 'alice.waters@example.com', 'alicew', 1, 'D6rQt2Vp'),
('Massimo', 'Bottura', 'massimo.bottura@example.com', 'massimob', 3, 'q8Nw1GsZ'),
('Rene', 'Redzepi', 'rene.redzepi@example.com', 'rener', 2, 'L4bRy7kJ'),
('Dan', 'Barber', 'dan.barber@example.com', 'danb', 1, 'x9Kj3MpQ'),
('Clare', 'Smyth', 'clare.smyth@example.com', 'clares', 2, 'H5nWp4zL'),
('Anne-Sophie', 'Pic', 'anne.sophie.pic@example.com', 'annes', 3, 'e2Ct7FdV'),
('Marco', 'Pierre White', 'marco.white@example.com', 'marcop', 2, 'G3rHs8yM'),
('Ferran', 'Adrià', 'ferran.adria@example.com', 'ferrana', 1, 'V6pDj0bN'),
('David', 'Chang', 'david.chang@example.com', 'davidc', 3, 'k9Zq2LtX'),
('Christina', 'Tosi', 'christina.tosi@example.com', 'christinat', 1, 'S7jBr5mW'),
('Grant', 'Achatz', 'grant.achatz@example.com', 'granta', 2, 'n4Yv1GcP'),
('Helena', 'Rizzo', 'helena.rizzo@example.com', 'helenar', 3, 'M8qSw6jK'),
('Dominique', 'Crenn', 'dominique.crenn@example.com', 'dominiquec', 1, 'z3Xp9LvD'),
('José', 'Andrés', 'jose.andres@example.com', 'josea', 2, 'T5cVr8yL'),
('Monica', 'Galetti', 'monica.galetti@example.com', 'monicag', 2, 'Q4jHs8mV'),
('Curtis', 'Stone', 'curtis.stone@example.com', 'curtiss', 1, 'Z9kRp3xT'),
('Alain', 'Ducasse', 'alain.ducasse@example.com', 'alaind', 3, 'V5yWq7bJ'),
('Carlo', 'Cracco', 'carlo.cracco@example.com', 'carloc', 2, 'M8tRz6pF'),
('Daniel', 'Humm', 'daniel.humm@example.com', 'danielh', 3, 'x2Nj9VkQ'),
('Anne', 'Burrell', 'anne.burrell@example.com', 'anneb', 1, 'G3qLp7yS'),
('Wolfgang', 'Puck', 'wolfgang.puck@example.com', 'wolfgangp', 2, 'H7fDs9zK'),
('Ina', 'Garten', 'ina.garten@example.com', 'inag', 3, 'W1jBr8vX'),
('Giada', 'De Laurentiis', 'giada.delaurentiis@example.com', 'giadad', 1, 'P6kFw4nL'),
('Mario', 'Batali', 'mario.batali@example.com', 'mariob', 2, 'R9sXt2cM'),
('Emeril', 'Lagasse', 'emeril.lagasse@example.com', 'emerill', 3, 'J8qZd5hV'),
('Rick', 'Stein', 'rick.stein@example.com', 'ricks', 1, 'S3yNp6tD'),
('Antonia', 'Lofaso', 'antonia.lofaso@example.com', 'antonial', 2, 'F5jXv9kQ'),
('Michael', 'Symon', 'michael.symon@example.com', 'michaels', 3, 'E2wTp7zN'),
('Aaron', 'Sanchez', 'aaron.sanchez@example.com', 'aarons', 1, 'L6cVr8yM'),
('José', 'Garces', 'jose.garces@example.com', 'joseg', 2, 'B4hRq5xP'),
('Christina', 'Martinez', 'christina.martinez@example.com', 'christinam', 3, 'T7vWp9zJ'),
('Alex', 'Guarnaschelli', 'alex.guarnaschelli@example.com', 'alexg', 1, 'C9qLt3wX'),
('Stephanie', 'Izard', 'stephanie.izard@example.com', 'stephaniei', 2, 'K5sRp7mV'),
('Nancy', 'Silverton', 'nancy.silverton@example.com', 'nancys', 3, 'D8zWj4qL'),
('Matilda', 'Stone', 'matilda.stone@example.com', 'matildas', 1, 'H4vTs9wQ'),
('Bradley', 'Cooper', 'bradley.cooper@example.com', 'bradleyc', 2, 'P7kWs4nM'),
('Serena', 'Morris', 'serena.morris@example.com', 'serenam', 3, 'X2jBr8yL'),
('Leonard', 'Foster', 'leonard.foster@example.com', 'leonardf', 1, 'D9zVp6kR'),
('Isabella', 'Reyes', 'isabella.reyes@example.com', 'isabellar', 2, 'M3cRj7vX'),
('Trevor', 'Nguyen', 'trevor.nguyen@example.com', 'trevorn', 3, 'K6sQw5tJ'),
('Felix', 'Martinez', 'felix.martinez@example.com', 'felixm', 1, 'Z5nGp2xV'),
('Camila', 'Bennett', 'camila.bennett@example.com', 'camilab', 2, 'L8yRt4wQ'),
('Julian', 'Lee', 'julian.lee@example.com', 'julianl', 3, 'R2hSv9mP'),
('Nina', 'Patel', 'nina.patel@example.com', 'ninap', 1, 'G7kWq3zD'),
('Victor', 'Lopez', 'victor.lopez@example.com', 'victorl', 2, 'E4pXr6tN');

INSERT INTO tblCategory (Category) VALUES
-- Recipe Categories
('Appetizer'),
('Main Course'),
('Dessert'),
('Soup'),
('Salad'),
('Bread'),
('Beverage'),
('Snack'),
('Seafood'),
('Vegetarian'),
('Vegan'),
('Gluten-Free'),
('Dairy-Free'),
('Pasta'),
('Rice'),
('Pizza'),
('Burger'),
('Sandwich'),
('Grill'),
('BBQ'),
('Breakfast'),
('Brunch'),
('Lunch'),
('Dinner'),
('Asian Cuisine'),
('Italian Cuisine'),
('Mexican Cuisine'),
('Indian Cuisine'),
('Mediterranean'),
('Comfort Food');

INSERT INTO tblRecipe (Title, Method, CategoryID, UserID, RegionID)
VALUES
('Spaghetti Carbonara', 'Cook pasta, mix with egg, cheese, and pancetta.', 15, 1, 130),
('Classic Burger', 'Grill the beef patty and assemble the burger.', 17, 2, 54),
('Margherita Pizza', 'Bake dough topped with tomato, mozzarella, and basil.', 16, 3, 131),
('Pumpkin Soup', 'Blend roasted pumpkin, onions, and stock.', 4, 4, 56),
('Caesar Salad', 'Combine lettuce, dressing, croutons, and parmesan.', 5, 5, 30),
('Chocolate Cake', 'Bake a rich chocolate cake with icing.', 3, 6, 98),
('Miso Soup', 'Simmer miso paste with dashi stock and tofu.', 4, 7, 134),
('Thai Green Curry', 'Cook chicken with green curry paste and coconut milk.', 25, 8, 122),
('BBQ Pork Ribs', 'Marinate and grill ribs with barbecue sauce.', 20, 9, 55),
('Vegetarian Tacos', 'Assemble tacos with beans, salsa, and cheese.', 10, 10, 110),
('Vegan Pad Thai', 'Stir-fry rice noodles, tofu, and tamarind sauce.', 11, 11, 123),
('French Baguette', 'Bake crusty French bread using yeast.', 6, 12, 99),
('Seafood Paella', 'Cook rice with seafood and saffron.', 9, 13, 6),
('Ratatouille', 'Stew vegetables like eggplant, zucchini, and tomatoes.', 29, 14, 98),
('Chicken Parmigiana', 'Bake chicken with tomato sauce and mozzarella.', 2, 15, 132),
('Beef Stroganoff', 'Cook beef with mushrooms and sour cream.', 1, 16, 26),
('Lentil Soup', 'Simmer lentils with vegetables and spices.', 4, 17, 124),
('Fish and Chips', 'Fry battered fish and serve with chips.', 2, 18, 128),
('Shepherds Pie', 'Bake mashed potatoes over minced meat.', 24, 19, 128),
('Butter Chicken', 'Cook chicken in creamy tomato curry sauce.', 28, 20, 119),
('Green Smoothie', 'Blend spinach, banana, and almond milk.', 7, 21, 15),
('Classic Lasagna', 'Layer pasta, bolognese, and bechamel sauce.', 15, 22, 130),
('Tofu Stir-Fry', 'Cook tofu with vegetables in soy sauce.', 11, 23, 64),
('Sourdough Bread', 'Ferment dough naturally and bake.', 6, 24, 104),
('Shakshuka', 'Cook eggs in a spicy tomato sauce.', 30, 25, 129),
('Pulled Pork Sandwich', 'Slow-cook pork and serve in a bun.', 18, 26, 54),
('Beef Wellington', 'Wrap beef in puff pastry and bake.', 2, 27, 128),
('Banana Pancakes', 'Cook pancakes with mashed banana.', 21, 28, 14),
('Quiche Lorraine', 'Bake quiche with bacon, cheese, and cream.', 24, 29, 98),
('Tom Yum Soup', 'Simmer shrimp with lemongrass and lime.', 25, 30, 122),
('Churros', 'Fry dough and coat with sugar and cinnamon.', 3, 31, 5),
('Ceviche', 'Cure raw fish in lime juice with onions.', 9, 32, 60),
('Veggie Burger', 'Grill a patty made with lentils and vegetables.', 10, 33, 56),
('Lamb Roast', 'Slow roast lamb with garlic and rosemary.', 20, 34, 16),
('Creme Brulee', 'Bake custard and caramelize sugar on top.', 3, 35, 98),
('Spring Rolls', 'Wrap vegetables in rice paper and fry.', 25, 36, 63),
('Pavlova', 'Bake a meringue base and top with cream and fruits.', 3, 37, 14),
('Beef Rendang', 'Slow-cook beef in coconut and spices.', 28, 38, 123),
('Paneer Tikka', 'Grill spiced paneer cubes on skewers.', 28, 39, 120),
('Chicken Caesar Wrap', 'Wrap chicken and salad in a tortilla.', 18, 40, 55),
('Ramen', 'Cook noodles in broth with toppings.', 25, 41, 135),
('Poke Bowl', 'Assemble raw fish, rice, and veggies in a bowl.', 30, 42, 142),
('Katsu Curry', 'Serve breaded chicken with curry sauce.', 2, 43, 136),
('Gnocchi', 'Cook potato gnocchi with tomato sauce.', 15, 44, 130),
('Tandoori Chicken', 'Roast chicken marinated in yogurt and spices.', 28, 45, 121),
('Pancit', 'Stir-fry noodles with vegetables and meat.', 25, 46, 122),
('Clam Chowder', 'Simmer clams with cream and potatoes.', 4, 47, 56),
('Croissant', 'Bake flaky butter pastry.', 6, 48, 99),
('Kimchi Fried Rice', 'Stir-fry rice with kimchi and egg.', 25, 49, 134),
('Stuffed Bell Peppers', 'Bake peppers filled with rice and meat.', 10, 50, 107);

INSERT INTO tblIngredient (Ingredient) VALUES
-- Basic Ingredients
('Salt'), ('Pepper'), ('Sugar'), ('Olive Oil'), ('Butter'),
('Milk'), ('Eggs'), ('Flour'), ('Garlic'), ('Onions'),
('Tomatoes'), ('Lemon Juice'), ('Soy Sauce'), ('Honey'), ('Vinegar'),
('Basil'), ('Parsley'), ('Thyme'), ('Rosemary'), ('Cilantro'),
('Oregano'), ('Chili Powder'), ('Paprika'), ('Cumin'), ('Mustard'),
-- Vegetables
('Carrots'), ('Potatoes'), ('Spinach'), ('Broccoli'), ('Cauliflower'),
('Zucchini'), ('Bell Peppers'), ('Celery'), ('Cabbage'), ('Mushrooms'),
('Avocado'), ('Green Beans'), ('Peas'), ('Sweet Corn'), ('Asparagus'),
-- Fruits
('Bananas'), ('Apples'), ('Oranges'), ('Strawberries'), ('Blueberries'),
('Raspberries'), ('Pineapple'), ('Mango'), ('Kiwi'), ('Grapes'),
('Watermelon'), ('Peaches'), ('Plums'), ('Coconut'), ('Lime'),
-- Protein
('Chicken Breast'), ('Ground Beef'), ('Pork Chop'), ('Salmon'), ('Shrimp'),
('Tofu'), ('Tempeh'), ('Turkey'), ('Eggplant'), ('Lentils'),
('Chickpeas'), ('Black Beans'), ('Kidney Beans'), ('White Beans'), ('Quinoa'),
-- Dairy
('Cheddar Cheese'), ('Parmesan Cheese'), ('Mozzarella Cheese'), ('Cream Cheese'), ('Yogurt'),
('Sour Cream'), ('Whipping Cream'), ('Feta Cheese'), ('Goat Cheese'), ('Ricotta Cheese'),
-- Grains
('White Rice'), ('Brown Rice'), ('Wild Rice'), ('Couscous'), ('Bulgar Wheat'),
('Pasta'), ('Spaghetti'), ('Macaroni'), ('Bread Crumbs'), ('Oats');

INSERT INTO tblIngredientStoreBridge (IngredientID, StoreID) VALUES
-- Salt available in 3 stores
(1, 1), (1, 2), (1, 3),
-- Pepper available in 3 stores
(2, 4), (2, 5), (2, 6),
-- Sugar available in 3 stores
(3, 7), (3, 8), (3, 9),
-- Olive Oil available in 3 stores
(4, 10), (4, 11), (4, 12),
-- Butter available in 3 stores
(5, 13), (5, 14), (5, 15),
-- Milk available in 3 stores
(6, 16), (6, 17), (6, 18),
-- Eggs available in 3 stores
(7, 19), (7, 20), (7, 21),
-- Flour available in 3 stores
(8, 22), (8, 23), (8, 24),
-- Garlic available in 3 stores
(9, 25), (9, 26), (9, 27),
-- Onions available in 3 stores
(10, 28), (10, 29), (10, 30),
-- Tomatoes available in 3 stores
(11, 31), (11, 32), (11, 33),
-- Lemon Juice available in 3 stores
(12, 34), (12, 35), (12, 36),
-- Soy Sauce available in 3 stores
(13, 37), (13, 38), (13, 39),
-- Honey available in 3 stores
(14, 40), (14, 41), (14, 42),
-- Vinegar available in 3 stores
(15, 43), (15, 44), (15, 45),
-- Basil available in 3 stores
(16, 46), (16, 47), (16, 48),
-- Parsley available in 3 stores
(17, 49), (17, 50), (17, 1),
-- Thyme available in 3 stores
(18, 2), (18, 3), (18, 4),
-- Rosemary available in 3 stores
(19, 5), (19, 6), (19, 7),
-- Cilantro available in 3 stores
(20, 8), (20, 9), (20, 10),
-- Oregano available in 3 stores
(21, 11), (21, 12), (21, 13),
-- Chili Powder available in 3 stores
(22, 14), (22, 15), (22, 16),
-- Paprika available in 3 stores
(23, 17), (23, 18), (23, 19),
-- Cumin available in 3 stores
(24, 20), (24, 21), (24, 22),
-- Mustard available in 3 stores
(25, 23), (25, 24), (25, 25),
-- Carrots available in 3 stores
(26, 26), (26, 27), (26, 28),
-- Potatoes available in 3 stores
(27, 29), (27, 30), (27, 31),
-- Spinach available in 3 stores
(28, 32), (28, 33), (28, 34),
-- Broccoli available in 3 stores
(29, 35), (29, 36), (29, 37),
-- Cauliflower available in 3 stores
(30, 38), (30, 39), (30, 40),
-- Zucchini available in 3 stores
(31, 41), (31, 42), (31, 43),
-- Bell Peppers available in 3 stores
(32, 44), (32, 45), (32, 46),
-- Celery available in 3 stores
(33, 47), (33, 48), (33, 49),
-- Cabbage available in 3 stores
(34, 50), (34, 1), (34, 2),
-- Mushrooms available in 3 stores
(35, 3), (35, 4), (35, 5),
-- Avocado available in 3 stores
(36, 6), (36, 7), (36, 8),
-- Green Beans available in 3 stores
(37, 9), (37, 10), (37, 11),
-- Peas available in 3 stores
(38, 12), (38, 13), (38, 14),
-- Sweet Corn available in 3 stores
(39, 15), (39, 16), (39, 17),
-- Asparagus available in 3 stores
(40, 18), (40, 19), (40, 20),
-- Bananas available in 3 stores
(41, 21), (41, 22), (41, 23),
-- Apples available in 3 stores
(42, 24), (42, 25), (42, 26),
-- Oranges available in 3 stores
(43, 27), (43, 28), (43, 29),
-- Strawberries available in 3 stores
(44, 30), (44, 31), (44, 32),
-- Blueberries available in 3 stores
(45, 33), (45, 34), (45, 35),
-- Raspberries available in 3 stores
(46, 36), (46, 37), (46, 38),
-- Pineapple available in 3 stores
(47, 39), (47, 40), (47, 41),
-- Mango available in 3 stores
(48, 42), (48, 43), (48, 44),
-- Kiwi available in 3 stores
(49, 45), (49, 46), (49, 47),
-- Grapes available in 3 stores
(50, 48), (50, 49), (50, 50),
-- Watermelon available in 3 stores
(51, 1), (51, 2), (51, 3),
-- Peaches available in 3 stores
(52, 4), (52, 5), (52, 6),
-- Plums available in 3 stores
(53, 7), (53, 8), (53, 9),
-- Coconut available in 3 stores
(54, 10), (54, 11), (54, 12),
-- Lime available in 3 stores
(55, 13), (55, 14), (55, 15),
-- Chicken Breast available in 3 stores
(56, 16), (56, 17), (56, 18),
-- Ground Beef available in 3 stores
(57, 19), (57, 20), (57, 21),
-- Pork Chop available in 3 stores
(58, 22), (58, 23), (58, 24),
-- Salmon available in 3 stores
(59, 25), (59, 26), (59, 27),
-- Shrimp available in 3 stores
(60, 28), (60, 29), (60, 30),
-- Tofu available in 3 stores
(61, 31), (61, 32), (61, 33),
-- Tempeh available in 3 stores
(62, 34), (62, 35), (62, 36),
-- Turkey available in 3 stores
(63, 37), (63, 38), (63, 39),
-- Eggplant available in 3 stores
(64, 40), (64, 41), (64, 42),
-- Lentils available in 3 stores
(65, 43), (65, 44), (65, 45),
-- Chickpeas available in 3 stores
(66, 46), (66, 47), (66, 48),
-- Black Beans available in 3 stores
(67, 49), (67, 50), (67, 1),
-- Kidney Beans available in 3 stores
(68, 2), (68, 3), (68, 4),
-- White Beans available in 3 stores
(69, 5), (69, 6), (69, 7),
-- Quinoa available in 3 stores
(70, 8), (70, 9), (70, 10),
-- Cheddar Cheese available in 3 stores
(71, 11), (71, 12), (71, 13),
-- Parmesan Cheese available in 3 stores
(72, 14), (72, 15), (72, 16),
-- Mozzarella Cheese available in 3 stores
(73, 17), (73, 18), (73, 19),
-- Cream Cheese available in 3 stores
(74, 20), (74, 21), (74, 22),
-- Yogurt available in 3 stores
(75, 23), (75, 24), (75, 25),
-- Sour Cream available in 3 stores
(76, 26), (76, 27), (76, 28),
-- Whipping Cream available in 3 stores
(77, 29), (77, 30), (77, 31),
-- Feta Cheese available in 3 stores
(78, 32), (78, 33), (78, 34),
-- Goat Cheese available in 3 stores
(79, 35), (79, 36), (79, 37),
-- Ricotta Cheese available in 3 stores
(80, 38), (80, 39), (80, 40),
-- White Rice available in 3 stores
(81, 41), (81, 42), (81, 43),
-- Brown Rice available in 3 stores
(82, 44), (82, 45), (82, 46),
-- Wild Rice available in 3 stores
(83, 47), (83, 48), (83, 49),
-- Couscous available in 3 stores
(84, 50), (84, 1), (84, 2),
-- Bulgar Wheat available in 3 stores
(85, 3), (85, 4), (85, 5),
-- Pasta available in 3 stores
(86, 6), (86, 7), (86, 8),
-- Spaghetti available in 3 stores
(87, 9), (87, 10), (87, 11),
-- Macaroni available in 3 stores
(88, 12), (88, 13), (88, 14),
-- Bread Crumbs available in 3 stores
(89, 15), (89, 16), (89, 17),
-- Oats available in 3 stores
(90, 18), (90, 19), (90, 20);

INSERT INTO tblRecipeIngredientBridge (RecipeID, IngredientID) VALUES
-- Recipe 1: Spaghetti Carbonara
(1, 87), (1, 7), (1, 72), -- Spaghetti, Eggs, Parmesan Cheese

-- Recipe 2: Classic Burger
(2, 57), (2, 89), (2, 5), -- Ground Beef, Bread Crumbs, Butter

-- Recipe 3: Margherita Pizza
(3, 8), (3, 73), (3, 16), -- Flour, Mozzarella Cheese, Basil

-- Recipe 4: Pumpkin Soup
(4, 10), (4, 12), (4, 26), -- Onions, Lemon Juice, Carrots

-- Recipe 5: Caesar Salad
(5, 17), (5, 15), (5, 72), -- Parsley, Vinegar, Parmesan Cheese

-- Recipe 6: Chocolate Cake
(6, 3), (6, 7), (6, 8), -- Sugar, Eggs, Flour

-- Recipe 7: Miso Soup
(7, 61), (7, 13), (7, 1), -- Tofu, Soy Sauce, Salt

-- Recipe 8: Thai Green Curry
(8, 56), (8, 54), (8, 24), -- Chicken Breast, Coconut, Cumin

-- Recipe 9: BBQ Pork Ribs
(9, 58), (9, 79), (9, 25), -- Pork Chop, Goat Cheese (simplified BBQ sauce), Mustard

-- Recipe 10: Vegetarian Tacos
(10, 67), (10, 32), (10, 20), -- Black Beans, Bell Peppers, Cilantro

-- Recipe 11: Vegan Pad Thai
(11, 87), (11, 61), (11, 24), -- Spaghetti (noodles alternative), Tofu, Cumin

-- Recipe 12: French Baguette
(12, 8), (12, 35), (12, 1), -- Flour, Yeast, Salt

-- Recipe 13: Seafood Paella
(13, 60), (13, 81), (13, 24), -- Shrimp, White Rice, Cumin

-- Recipe 14: Ratatouille
(14, 64), (14, 31), (14, 11), -- Eggplant, Zucchini, Tomatoes

-- Recipe 15: Chicken Parmigiana
(15, 56), (15, 73), (15, 11), -- Chicken Breast, Mozzarella Cheese, Tomatoes

-- Recipe 16: Beef Stroganoff
(16, 57), (16, 35), (16, 76), -- Ground Beef, Mushrooms, Sour Cream

-- Recipe 17: Lentil Soup
(17, 65), (17, 26), (17, 9), -- Lentils, Carrots, Garlic

-- Recipe 18: Fish and Chips
(18, 59), (18, 27), (18, 8), -- Salmon (fish alternative), Potatoes, Flour

-- Recipe 19: Shepherd’s Pie
(19, 57), (19, 27), (19, 71), -- Ground Beef, Potatoes, Cheddar Cheese

-- Recipe 20: Butter Chicken
(20, 56), (20, 77), (20, 13), -- Chicken Breast, Whipping Cream, Soy Sauce (simplified spices)

-- Recipe 21: Green Smoothie
(21, 28), (21, 41), (21, 6), -- Spinach, Banana, Milk

-- Recipe 22: Classic Lasagna
(22, 86), (22, 57), (22, 11), -- Pasta, Ground Beef, Tomatoes

-- Recipe 23: Tofu Stir-Fry
(23, 61), (23, 32), (23, 13), -- Tofu, Bell Peppers, Soy Sauce

-- Recipe 24: Sourdough Bread
(24, 8), (24, 35), (24, 1), -- Flour, Yeast, Salt

-- Recipe 25: Shakshuka (simplified)
(25, 11), (25, 7), (25, 9), -- Tomatoes, Eggs, Garlic

-- Recipe 26: Pulled Pork Sandwich
(26, 58), (26, 89), (26, 5), -- Pork Chop, Bread Crumbs, Butter

-- Recipe 27: Beef Wellington
(27, 57), (27, 88), (27, 35), -- Ground Beef, Puff Pastry, Mushrooms

-- Recipe 28: Banana Pancakes
(28, 41), (28, 8), (28, 7), -- Bananas, Flour, Eggs

-- Recipe 29: Quiche Lorraine
(29, 7), (29, 72), (29, 5), -- Eggs, Parmesan Cheese, Butter

-- Recipe 30: Tom Yum Soup
(30, 60), (30, 55), (30, 13), -- Shrimp, Lime, Soy Sauce

-- Recipe 31: Churros
(31, 8), (31, 3), (31, 22), -- Flour, Sugar, Cinnamon

-- Recipe 32: Ceviche
(32, 59), (32, 55), (32, 10), -- Salmon, Lime, Onions

-- Recipe 33: Veggie Burger
(33, 65), (33, 32), (33, 9), -- Lentils, Bell Peppers, Garlic

-- Recipe 34: Lamb Roast
(34, 57), (34, 19), (34, 9), -- Ground Beef, Rosemary, Garlic

-- Recipe 35: Creme Brulee
(35, 77), (35, 3), (35, 7), -- Whipping Cream, Sugar, Eggs

-- Recipe 36: Spring Rolls
(36, 32), (36, 13), (36, 28), -- Bell Peppers, Soy Sauce, Spinach

-- Recipe 37: Pavlova
(37, 7), (37, 3), (37, 77), -- Egg Whites, Sugar, Whipping Cream

-- Recipe 38: Beef Rendang
(38, 57), (38, 54), (38, 24), -- Ground Beef, Coconut, Cumin

-- Recipe 39: Paneer Tikka
(39, 61), (39, 75), (39, 24), -- Tofu, Yogurt, Cumin

-- Recipe 40: Chicken Caesar Wrap
(40, 56), (40, 17), (40, 89), -- Chicken Breast, Parsley, Bread Crumbs

-- Recipe 41: Ramen
(41, 87), (41, 77), (41, 7), -- Spaghetti, Whipping Cream, Eggs

-- Recipe 42: Poke Bowl
(42, 81), (42, 60), (42, 32), -- White Rice, Shrimp, Bell Peppers

-- Recipe 43: Katsu Curry
(43, 89), (43, 56), (43, 13), -- Bread Crumbs, Chicken Breast, Soy Sauce

-- Recipe 44: Gnocchi
(44, 27), (44, 8), (44, 11), -- Potatoes, Flour, Tomatoes

-- Recipe 45: Tandoori Chicken
(45, 56), (45, 75), (45, 24), -- Chicken Breast, Yogurt, Cumin

-- Recipe 46: Pancit
(46, 87), (46, 13), (46, 57), -- Spaghetti, Soy Sauce, Ground Beef

-- Recipe 47: Clam Chowder
(47, 60), (47, 27), (47, 77), -- Clams, Potatoes, Whipping Cream

-- Recipe 48: Croissant
(48, 5), (48, 8), (48, 35), -- Butter, Flour, Yeast

-- Recipe 49: Kimchi Fried Rice
(49, 81), (49, 34), (49, 7), -- White Rice, Kimchi, Eggs

-- Recipe 50: Stuffed Bell Peppers
(50, 32), (50, 81), (50, 57); -- Bell Peppers, White Rice, Ground Beef
