/*1. Напишите код вычисления суммы всех нечетных чисел от 0 до заданного числа N
- Спрашиваем у пользователя через prompt
- Переводим в number(потому что из prompt мы получаем строку)
- Дальше думаем сами
В конце просто я должен увидеть сумму от 0 до N числа, который я ввёл*/
let value=prompt("Введите число")
if(!isNaN(Number(value)))
{
  let temp=0
   for(let i=0;i<Number(value);i++)
   { 
     if(i%2!=0) temp+=i
   }
   alert("Сумма: "+ temp)
}
else alert(value+" не число")