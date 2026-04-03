select 
t1.productId,
t1.productName,
t2.productPrice,
From Table t1
Inner Join Table t2
on t1.productId=t2.productId where t2.price >500;

