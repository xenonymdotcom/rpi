
all: test libpigpio.so

test: libpigpio.so main.c
	gcc -L. -Wall -o test main.c -lpigpio

libpigpio.so : libpigpio.o
	gcc -shared -o libpigpio.so libpigpio.o

libpigpio.o : libpigpio.c libpigpio.h
	gcc -c -fpic -Wall libpigpio.c

install : libpigpio.so
	sudo cp libpigpio.so /lib

clean :
	rm *.o *.so
