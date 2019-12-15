/*
02. Создайте три переменные с любыми числовыми значениями. Используя условный оператор  и не используя логические, 
найдите минимальное число и отобразите на экране имя переменной и ее значение.
*/
let val1=10
let val2=20
let val3=30

let obj={val1,val2,val3}

function minFun()
{
    let min=arguments[0];
    for(let i=1;i<arguments.length;i++)
    {
        if(min> arguments[i]) min=arguments[i];
    }
    return min;
}

let temp=minFun(val1,val2,val3);



for(let key in obj)
{
    if(obj[key]==temp) console.log(key+':'+temp)
}