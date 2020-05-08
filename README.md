# WebApi домашние задание ModulStart

### Создание таблицы
```
CREATE TABLE users1
(
    Id SERIAL PRIMARY KEY,
    username CHARACTER VARYING(30),
    email CHARACTER VARYING(30),
    passwordHash CHARACTER VARYING(255),
    salt CHARACTER VARYING(30),
    accountNumber BIGINT,
    balance REAL
);
```

### Регистрация пользователя
- Выполнить post запрос  
https://localhost:44306/api/token/registration  
В body написать следующий код:  
```
{
	"email":"example@mail.ru",
	"username":"Petr",
	"password":"bestparol",
	"passwordconfirm":"bestparol"
}
```
- Если регистрация прошла успешно, то будет получен токен
### Авторизация
- Выполнить post запрос  
https://localhost:44306/api/token/authorization  
В body написать следующий код:  
```
{
	"email":"example@mail.ru",
	"password":"bestparol"
}
```
- Если авторизация прошла успешно, то будет получен токен
### Пополнение счета
- Выполнить put запрос  
https://localhost:44306/api/money/topup  
В body написать следующий код:
```
{
	"toaccount":4403796758,
	"howmuch":500
}
```  
- toaccont - номер счета, которой будет пополняться
- howmuch - на сколько пополнится указанный счет
### Перевод на счет
- Выполнить put запрос  
https://localhost:44306/api/money/transfer  
В body написать следующий код  
```
{
	"fromaccount":4234701553,
	"toaccount":4403796758,
	"howmuch":100
}
```
- fromaccount - номер счета с которого спишутся средства
- toaccount - номер счета на который переведутся средства
- howmuch - сколько средств необходимо перевести
