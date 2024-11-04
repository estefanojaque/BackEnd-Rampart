# Instrucciones para la Base de Datos del Backend

Este archivo contiene las instrucciones para configurar manualmente la base de datos MySQL necesaria para el backend del proyecto.

## Crear la Base de Datos

Conéctate a MySQL y ejecuta los siguientes comandos para crear la base de datos y las tablas necesarias.

### Crear la Base de Datos

```sql
CREATE DATABASE BackEnd;
USE BackEnd;

CREATE TABLE `order` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    order_date DATETIME NOT NULL,
    delivery_date DATETIME NOT NULL,
    payment_method VARCHAR(50) NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL,
    status VARCHAR(50) NOT NULL,
    preferences_json TEXT,
    details_shown BOOLEAN NOT NULL
);

CREATE TABLE user_profiles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    photo VARCHAR(255) NOT NULL,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    birth_date DATE NOT NULL,
    address TEXT NOT NULL,
    paymentmethod VARCHAR(50) NOT NULL,
    cardnumber VARCHAR(20) NOT NULL,
    yapenumber VARCHAR(20) NOT NULL,
    cashpayment BOOLEAN NOT NULL,
    preferencesJson TEXT
);

CREATE TABLE dishes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    chef_name VARCHAR(100) NOT NULL,
    name_of_dish VARCHAR(100) NOT NULL,
    ingredients_json TEXT NOT NULL,
    preparation_steps_json TEXT NOT NULL,
    favorite BOOLEAN NOT NULL
);
