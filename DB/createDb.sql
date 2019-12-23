create database pro1abd;
GO
use pro1abd;
-- tables
-- Table: Additives
CREATE TABLE Additives (
    id int  NOT NULL IDENTITY(1,1),
    name int  NOT NULL,
    net_price decimal(2,2)  NOT NULL,
    CONSTRAINT Additives_pk PRIMARY KEY  (id)
);

-- Table: Additives_list
CREATE TABLE Additives_list (
    additives_list_id int  NOT NULL IDENTITY(1,1),
    order_item_id int  NOT NULL,
    additives_id int  NOT NULL,
    CONSTRAINT Additives_list_pk PRIMARY KEY  (additives_list_id)
);

-- Table: Client
CREATE TABLE Client (
    client_id int  NOT NULL IDENTITY(1,1),
    name varchar(100)  NOT NULL,
    email varchar(50)  NOT NULL,
    address varchar(255)  NOT NULL,
    CONSTRAINT Client_pk PRIMARY KEY  (client_id)
);

-- Table: Order
CREATE TABLE "Order" (
    id int  NOT NULL IDENTITY(1,1),
    client_id int  NOT NULL,
    is_paid tinyint  NOT NULL,
    promotion_id int  NOT NULL,
    status_id int  NOT NULL,
    pay_method_id int  NOT NULL,
    CONSTRAINT Order_pk PRIMARY KEY  (id)
);

-- Table: Order_item
CREATE TABLE Order_item (
    id int  NOT NULL IDENTITY(1,1),
    order_id int  NOT NULL,
    pizza_id int  NOT NULL,
    count int  NOT NULL,
    CONSTRAINT Order_item_pk PRIMARY KEY  (id)
);

-- Table: Pay_method_dict
CREATE TABLE Pay_method_dict (
    id int  NOT NULL IDENTITY(1,1),
    name varchar(20)  NOT NULL,
    CONSTRAINT Pay_method_dict_pk PRIMARY KEY  (id)
);

-- Table: Pizza
CREATE TABLE Pizza (
    id int  NOT NULL IDENTITY(1,1),
    name varchar(20)  NOT NULL,
    description varchar(100)  NOT NULL,
    net_price decimal(5,2)  NOT NULL,
    CONSTRAINT Pizza_pk PRIMARY KEY  (id)
);

-- Table: Promotion
CREATE TABLE Promotion (
    id int  NOT NULL IDENTITY(1,1),
    name varchar(50)  NOT NULL,
    amount int  NOT NULL,
    is_active tinyint  NOT NULL,
    CONSTRAINT Promotion_pk PRIMARY KEY  (id)
);

-- Table: Status_dict
CREATE TABLE Status_dict (
    id int  NOT NULL IDENTITY(1,1),
    name varchar(20)  NOT NULL,
    CONSTRAINT Status_dict_pk PRIMARY KEY  (id)
);

-- foreign keys
-- Reference: Ingridients_Ingredients_list (table: Additives_list)
ALTER TABLE Additives_list ADD CONSTRAINT Ingridients_Ingredients_list
    FOREIGN KEY (additives_id)
    REFERENCES Additives (id);

-- Reference: Order_Client (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_Client
    FOREIGN KEY (client_id)
    REFERENCES Client (client_id);

-- Reference: Order_item_Ingredients_list (table: Additives_list)
ALTER TABLE Additives_list ADD CONSTRAINT Order_item_Ingredients_list
    FOREIGN KEY (order_item_id)
    REFERENCES Order_item (id);

-- Reference: Order_item_Order (table: Order_item)
ALTER TABLE Order_item ADD CONSTRAINT Order_item_Order
    FOREIGN KEY (order_id)
    REFERENCES "Order" (id)
    ON DELETE  CASCADE;

-- Reference: Order_item_Pizza (table: Order_item)
ALTER TABLE Order_item ADD CONSTRAINT Order_item_Pizza
    FOREIGN KEY (pizza_id)
    REFERENCES Pizza (id);

-- Reference: Order_pay_method_dict (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_pay_method_dict
    FOREIGN KEY (pay_method_id)
    REFERENCES Pay_method_dict (id);

-- Reference: Order_promotion (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_promotion
    FOREIGN KEY (promotion_id)
    REFERENCES Promotion (id);

-- Reference: Order_status_dict (table: Order)
ALTER TABLE "Order" ADD CONSTRAINT Order_status_dict
    FOREIGN KEY (status_id)
    REFERENCES Status_dict (id);

-- End of file.

insert into Client(name, email, address) values('Grzegorz', 's0000@pjwstk.edu.pl','00-523 Warszawa');

insert into Pay_method_dict(name) values('Blik'),('Przelew'),('Gotówka');

insert into Client(name, email, address) values('Grzegorz', 's0000@pjwstk.edu.pl','00-523 Warszawa');

insert into Pay_method_dict(name) values('Blik'),('Przelew'),('Gotówka');

insert into Promotion(name, amount, is_active) values('Brak',0,1), ('Dwie w cenie jednej',0,1);

insert into Status_dict(name) values('Przyjęcie'),('Przygotowanie'),('Pieczenie'),('Dostawa');

insert into "Order"(client_id, is_paid, promotion_id,status_id, pay_method_id) values(1, 0, 1, 1, 1)

insert into Pizza(name, description, net_price) values('Pepperoni', 'Pizaa z ...', 2.1);

insert into Order_item(order_id, pizza_id, count) values(1,1,1);
