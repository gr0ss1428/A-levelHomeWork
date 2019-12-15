/*
04. В переменную day записан текущий день недели. Если это не суббота и не воскресенье, выведите в console.log сообщение о необходимости идти на работу.
*/
let day="понедельник"
if(day.toLocaleLowerCase().localeCompare("Суббота".toLocaleLowerCase())!=0&&day.toLocaleLowerCase().localeCompare("воскресенье".toLocaleLowerCase())!=0) console.log("Пора на работу")