using System;

class Program
{
    static void Main(string[] args)
    {
        ListaCircular listaCircular = new ListaCircular();

        listaCircular.Agregar(10);
        listaCircular.Agregar(20);
        listaCircular.Agregar(30);
        Console.WriteLine("Lista despues de agregar datos:");
        listaCircular.ImprimirLista();

        Console.WriteLine("Buscando datos 20 y 50 en la lista:");
        listaCircular.Buscar(20);
        listaCircular.Buscar(50);

        Console.WriteLine("Modificar datos, cambiando dato '20' a '50' en la lista:");
        listaCircular.Modificar(20, 50);
        listaCircular.ImprimirLista();


        Console.WriteLine("Eliminar datos, Eliminando dato '50' de la lista y agregando 60:");
        listaCircular.Eliminar(50);
        listaCircular.Agregar(60);
        listaCircular.ImprimirLista();
    }
}

class NodoCircular
{
    public int dato;
    public NodoCircular siguiente;

    public NodoCircular(int dato)
    {
        this.dato = dato;
        siguiente = null;
    }
}

class ListaCircular
{
    private NodoCircular cabeza;

    public ListaCircular()
    {
        cabeza = null;
    }

    public void Agregar(int dato)
    {
        NodoCircular nuevoNodo = new NodoCircular(dato);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            cabeza.siguiente = cabeza;
        }
        else
        {
            NodoCircular actual = cabeza;
            while (actual.siguiente != cabeza)
            {
                actual = actual.siguiente;
            }
            actual.siguiente = nuevoNodo;
            nuevoNodo.siguiente = cabeza;
        }
    }

    public void Eliminar(int dato)
    {
        if (cabeza == null) return;
        NodoCircular actual = cabeza;
        NodoCircular anterior = null;
        do
        {
            if (actual.dato == dato)
            {
                if (anterior != null)
                {
                    anterior.siguiente = actual.siguiente;
                }
                else
                {
                    if (actual.siguiente == cabeza)
                    {
                        cabeza = null;
                    }
                    else
                    {
                        NodoCircular temp = cabeza;
                        while (temp.siguiente != cabeza)
                        {
                            temp = temp.siguiente;
                        }
                        cabeza = cabeza.siguiente;
                        temp.siguiente = cabeza;
                    }
                }
                Console.WriteLine("Elemento eliminado.");
                return;
            }
            anterior = actual;
            actual = actual.siguiente;
        } while (actual != cabeza);
        Console.WriteLine("Elemento no encontrado.");
    }

    public void Buscar(int dato)
    {
        if (cabeza == null) return;
        NodoCircular actual = cabeza;
        do
        {
            if (actual.dato == dato)
            {
                Console.WriteLine("Elemento encontrado: " + dato);
                return;
            }
            actual = actual.siguiente;
        } while (actual != cabeza);
        Console.WriteLine("Elemento no encontrado.");
    }

    public void Modificar(int dato, int nuevoDato)
    {
        if (cabeza == null) return;
        NodoCircular actual = cabeza;
        do
        {
            if (actual.dato == dato)
            {
                actual.dato = nuevoDato;
                Console.WriteLine("Elemento modificado.");
                return;
            }
            actual = actual.siguiente;
        } while (actual != cabeza);
        Console.WriteLine("Elemento no encontrado.");
    }

    public void ImprimirLista()
    {
        if (cabeza == null) return;
        NodoCircular actual = cabeza;
        do
        {
            Console.Write(actual.dato + " ");
            actual = actual.siguiente;
        } while (actual != cabeza);
        Console.WriteLine();
    }
}
