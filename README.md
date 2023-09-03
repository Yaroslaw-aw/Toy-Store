# Toy Store
## Можно создать пустую машину и заполнять её с нуля.
## Я создал с начала несколько игрушек просто для демонстрации, чтобы показать что каждый класс нормально функционирует и чтобы проверить функции программы, не тратя время на добавление большого количества игрушек самостоятельно.
У игрушки нельзя менять % выпадения (просто потому что это нелогично), но зато можно менять её "вес". А процент выпадения высчитывается исходя из доли веса игрушки общем "весе" всех игрушек (от количества игрушек не зависит, у каждого типа игрушки свой "фиксированный" вес). Т.е. если у нас в автомате будет всего 1 игрушка, какой бы у неё ни был вес, шанс её выпадения будет 100%, но если добавляется ещё одна игрушка, то их проценты выпадения пересчитываются исходя из их веса. Какую долю вес каждой игрушки занимает в совокупном весе всех игрушек - такой процент выпадения и будет. Например, у мишки вес 350, а у гномика 150 - шанс выпадения мишки будет 70%, а гномика, соответственно 30%. По итогу, у нас никогда не будет суммарный шанс выпадения игрушем меньше 100% или больше 100%, всегда будет саммарно 100%, что логично.
