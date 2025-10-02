def create():
    with open('Notes.txt', 'a') as file:
        file.write(input('Введите новую заметку: '))

def delete():
    with open('Notes.txt', 'r+') as file:
        lst = file.readlines()
        print(lst)
        for i in range(len(lst)):
            print(f'{i+1} - {lst[i][:25:]}')
        ind_del_note = int(input('\nВведите номер удаляемой заметки: '))-1
        lst.pop(ind_del_note)
        print(lst)
        file.truncate(0)
        for i in lst:
            file.writelines(i)
               
def search():
    searched_phrase = input("Введите строчку для поиска: ")
    with open('Notes.txt', 'r') as file:
        lst = file.readlines()
    for i in lst:
        if searched_phrase in i:
            print(i)

def close():
    exit()

def show():
#    print("qwerty")
    with open('Notes.txt', 'r') as file:
        lst = file.readlines()
#        print(lst)
        for i in range(len(lst)-1):
                print(lst[i][:-1:])
        print(lst[-1])

def interface():
    print('Мы рады приветствовать Вас в нашем приложении для работы с заметками!')
    while True:
        answer = input(('''   Доступные действия:
        1 - создать заметку;
        2 - удалить заметку;
        3 - найти заметку;
        4 - закрыть заметку;
        5 - показать заметку.
    Для выбора команды напишите номер команды: '''))
#        print('qwerty')
        match answer:
            case "1":
                create()
            case "2":
                delete()
            case "3":
                search()
            case "4":
                close()
            case "5":
#                print('qwerty222')
                show()
            case _:  #остальные варианты ввода пользователя
                print("Неверое число! Попробуйте снова!")
        continue

interface()