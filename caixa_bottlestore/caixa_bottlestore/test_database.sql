-- Script de teste para verificar se o banco está configurado corretamente
-- Execute este script no MySQL para verificar se tudo está funcionando

USE bottle_store;

-- Verificar se as tabelas existem
SHOW TABLES;

-- Verificar estrutura da tabela products
DESCRIBE products;

-- Verificar se há produtos cadastrados
SELECT COUNT(*) as total_produtos FROM products;

-- Verificar estrutura da tabela sales
DESCRIBE sales;

-- Verificar estrutura da tabela sale_items
DESCRIBE sale_items;

-- Verificar produtos existentes
SELECT id, name, description, price, stock_quantity, created_at FROM products;

