using System;
using System.Collections.Generic;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new();

            counter.OnIncremented += (object obj, ValueChangedArgs args) => { Console.WriteLine($"Value = {args.Value}"); };
            counter.OnDecremented += (object obj, ValueChangedArgs args) => { Console.WriteLine($"Value = {args.Value}"); };

            counter.Increment();
            counter.Increment();
            counter.Increment();
            counter.Increment();
            Console.WriteLine("////////");
            counter.Decrement();
            counter.Decrement();
            counter.Decrement();
            counter.Decrement();

            Console.WriteLine("////////observableList1////////");
            ObservableList1<int> observableList1 = new();
            observableList1.OnAdded += (Object obj, TValueChangedArgs<int> args) => { Console.WriteLine($"Added: {args.Value}"); };
            observableList1.OnUpdated += (Object obj, TValueUpdatedArgs<int> args) => { Console.WriteLine($"Updated: {args.Value}"); };
            observableList1.OnRemovedAt += (Object obj, TValueChangedArgs<int> args) => { Console.WriteLine($"Removed: {args.Value}"); };

            void added(Object obj, TValueChangedArgs<int> args) { Console.WriteLine($"Added: {args.Value}"); }
            void updated(Object obj, TValueUpdatedArgs<int> args) { Console.WriteLine($"Updated: {args.Value}"); }
            void removed(Object obj, TValueChangedArgs<int> args) { Console.WriteLine($"Removed: {args.Value}"); }

            observableList1.OnAdded += added;
            observableList1.OnUpdated += updated;
            observableList1.OnRemovedAt += removed;

            observableList1.Add(5);
            observableList1.Add(55);
            observableList1.Add(324);
            observableList1.Add(15);

            Console.WriteLine(observableList1.Length);

            observableList1.RemoveAt(0);
            observableList1.RemoveAt(0);
            observableList1.RemoveAt(0);
            observableList1.RemoveAt(0);

            Console.WriteLine("After removing OnAdded event");
            observableList1.OnAdded -= added;

            observableList1.Add(5);
            observableList1.Add(55);
            observableList1.Add(324);
            observableList1.Add(15);

            Console.WriteLine(observableList1.Length);

            observableList1.RemoveAt(0);
            observableList1.RemoveAt(0);
            observableList1.RemoveAt(0);
            observableList1.RemoveAt(0);

            Console.WriteLine("////////observableList2////////");
            ObservableList2<int> observableList2 = new ObservableList2<int>(
                (object obj, TValueChangedArgs<int> args) => { Console.WriteLine($"Added: {args.Value}"); },
                (object obj, TValueUpdatedArgs<int> args) => { Console.WriteLine($"Updated: {args.Value}"); },
                (object obj, TValueChangedArgs<int> args) => { Console.WriteLine($"Removed: {args.Value}"); }
                );

            observableList2.Add(5);
            observableList2.Add(55);
            observableList2.Add(324);
            observableList2.Add(15);

            Console.WriteLine(observableList2.Length);

            observableList2.RemoveAt(0);
            observableList2.RemoveAt(0);
            observableList2.RemoveAt(0);
            observableList2.RemoveAt(0);


            ObservableList2<int> observableList22 = new ObservableList2<int>(
                added,
                updated,
                removed
                );

            observableList22.Add(5);
            observableList22.Add(55);
            observableList22.Add(324);
            observableList22.Add(15);

            Console.WriteLine(observableList22.Length);

            observableList22.RemoveAt(0);
            observableList22.RemoveAt(0);
            observableList22.RemoveAt(0);
            observableList22.RemoveAt(0);
        }
    }

    public class Counter
    {
        private int count = 0;

        public virtual void Increment()
        {
            count++;
            OnIncrementedHandler(new ValueChangedArgs() { Value = count });
        }

        public virtual void Decrement()
        {
            count--;
            OnDecrementedHandler(new ValueChangedArgs() { Value = count });
        }

        protected virtual void OnIncrementedHandler(ValueChangedArgs e)
        {
            EventHandler<ValueChangedArgs> handler = OnIncremented;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnDecrementedHandler(ValueChangedArgs e)
        {
            EventHandler<ValueChangedArgs> handler = OnDecremented;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<ValueChangedArgs> OnIncremented;
        public event EventHandler<ValueChangedArgs> OnDecremented;
    }

    public class ValueChangedArgs : EventArgs
    {
        public int Value { get; set; }
    }

    public class TValueChangedArgs<T> : EventArgs
    {
        public T Value { get; set; }
    }
    public class TValueUpdatedArgs<T> : EventArgs
    {
        public T Value { get; set; }
        public int Index { get; set; }
    }


    public class ExtenderCounter : Counter
    {
        public override void Increment()
        {
            base.Increment();
            Console.WriteLine("Incremented!");
        }

        public override void Decrement()
        {
            base.Decrement();
            Console.WriteLine("Decremented!");
        }
    }

    public class ObservableList1<T>
    {
        public int Length { get; set; }
        List<T> List = new List<T>();

        public void Add(T value)
        {
            Length++;
            List.Add(value);
            AddedHandler(new TValueChangedArgs<T>() { Value = value });
        }

        public T Get(int index)
        {
            T returnValue = List[index];
            UpdatedHandler(new TValueUpdatedArgs<T>() { Value = returnValue, Index = index });
            return returnValue;
        }

        public void Set(int index, T value)
        {
            List[index] = value;
            UpdatedHandler(new TValueUpdatedArgs<T>() { Value = value, Index = index });
        }

        public void RemoveAt(int index)
        {
            T value = List[index];
            List.RemoveAt(index);
            RemovedAtHandler(new TValueChangedArgs<T>() { Value = value });
        }

        protected virtual void AddedHandler(TValueChangedArgs<T> e)
        {
            EventHandler<TValueChangedArgs<T>> handler = OnAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void UpdatedHandler(TValueUpdatedArgs<T> e)
        {
            EventHandler<TValueUpdatedArgs<T>> handler = OnUpdated;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void RemovedAtHandler(TValueChangedArgs<T> e)
        {
            EventHandler<TValueChangedArgs<T>> handler = OnRemovedAt;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<TValueChangedArgs<T>> OnAdded;
        public event EventHandler<TValueUpdatedArgs<T>> OnUpdated;
        public event EventHandler<TValueChangedArgs<T>> OnRemovedAt;
    }


    public delegate void AddAction<T>(object obj, TValueChangedArgs<T> args);
    public delegate void UpdateAction<T>(object obj, TValueUpdatedArgs<T> args);
    public delegate void RemoveAction<T>(object obj, TValueChangedArgs<T> args);

    public class ObservableList2<T>
    {
        public int Length { get; set; }
        List<T> List = new List<T>();

        public ObservableList2(AddAction<T> add, UpdateAction<T> update, RemoveAction<T> remove)
        {
            OnAdded += new EventHandler<TValueChangedArgs<T>>(add);
            OnUpdated += new EventHandler<TValueUpdatedArgs<T>>(update);
            OnRemovedAt += new EventHandler<TValueChangedArgs<T>>(remove);
        }

        public void Add(T value)
        {
            Length++;
            List.Add(value);
            AddedHandler(new TValueChangedArgs<T>() { Value = value });
        }

        public T Get(int index)
        {
            T returnValue = List[index];
            UpdatedHandler(new TValueUpdatedArgs<T>() { Value = returnValue });
            return returnValue;
        }

        public void Set(int index, T value)
        {
            List[index] = value;
            UpdatedHandler(new TValueUpdatedArgs<T>() { Value = value });
        }

        public void RemoveAt(int index)
        {
            T value = List[index];
            List.RemoveAt(index);
            RemovedAtHandler(new TValueChangedArgs<T>() { Value = value });
        }

        protected virtual void AddedHandler(TValueChangedArgs<T> e)
        {
            EventHandler<TValueChangedArgs<T>> handler = OnAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void UpdatedHandler(TValueUpdatedArgs<T> e)
        {
            EventHandler<TValueUpdatedArgs<T>> handler = OnUpdated;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void RemovedAtHandler(TValueChangedArgs<T> e)
        {
            EventHandler<TValueChangedArgs<T>> handler = OnRemovedAt;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<TValueChangedArgs<T>> OnAdded;
        public event EventHandler<TValueUpdatedArgs<T>> OnUpdated;
        public event EventHandler<TValueChangedArgs<T>> OnRemovedAt;
    }

}
