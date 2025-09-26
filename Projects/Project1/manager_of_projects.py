def create():
    pass # не реализовано, но будет работать. Можно заменить на '...'

def delete():
    pass

def search():
    pass

def close():
    pass

def show():
    pass

def interface():
    print('Мы рады приветствовать Вас в нашем приложении для работы с заметками!')
    while True:
        answer = int(input('''   Доступные действия:
        1 - создать заметку;
        2 - удалить заметку;
        3 - найти заметку;
        4 - закрыть заметку;
        5 - показать заметку.
    Для выбора команды напишите номер команды.'''))
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
                show()
            case _:  #остальные варианты ввода пользователя
                print("Неверое число! Попробуйте снова!")
        continue

interface()